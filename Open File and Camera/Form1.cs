using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;

using OpenCvSharp;
using OpenCvSharp.Extensions;


namespace Test_Chaper4
{
    public partial class Form1 : Form
    {
        Thread ThreadCam;
        Thread ThreadVideo;
        Mat mat;
        VideoCapture cap;

        bool isCamOn;
        bool isVideoOn;
        int delay;

        public Form1()
        {
            InitializeComponent();

            PB1.SizeMode = PictureBoxSizeMode.StretchImage;
            PB2.SizeMode = PictureBoxSizeMode.StretchImage;
            isCamOn = false;
            isVideoOn = false;
        }

        private void BT1_Click(object sender, EventArgs e)
        {
            if (isCamOn)
            {
                if (cap.IsOpened())
                {
                    msg(String.Format("Already video or CAM is running"));
                    return;

                }
            }
            else if (isVideoOn)
            {
                if (cap.IsOpened())
                {
                    ThreadVideo.Abort();
                    if (PB1.Image != null) PB1.Image.Dispose();
                    cap.Release();
                    mat.Release();
                    isVideoOn = false;
                    Invoke((MethodInvoker)delegate { BT1.Text = "Load File"; });
                    msg(String.Format("Stopped Video"));
                }
            }
            else
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(dlg.FileName);

                    String[] video = { ".avi", ".mp4", "mpg", "mpeg" };
                    String[] image = { ".bmp", ".jpg", ".jpeg" };

                    foreach (String str in video)
                    {
                        if (fi.Extension == str)
                        {
                            mat = new Mat();
                            cap = new VideoCapture(dlg.FileName);

                            msg(String.Format("Start CAM - Width:{0} Height:{1}", cap.FrameWidth, cap.FrameHeight));
                            msg(String.Format("FS : {0}", cap.Fps));
                            delay = Convert.ToInt16(1000.0 / cap.Fps);
                            msg(String.Format("delay : {0}", delay));
                            msg(String.Format("Total Frame : {0}", cap.Get(VideoCaptureProperties.FrameCount)));

                            if (!cap.IsOpened())
                            {
                                msg("Can't run video");
                                return;
                            }
                            try
                            {
                                ThreadVideo = new Thread(new ThreadStart(VideoCallback));
                                ThreadVideo.Start();
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show(exc.Message);
                            }
                        }
                    }

                    foreach (String str in image)
                    {
                        if (fi.Extension == str)
                        {
                            mat = Cv2.ImRead(dlg.FileName);

                            Rect rect = new Rect(100, 100, 300, 300);
                            Mat mat2 = new Mat();
                            
                            PB1.Image = BitmapConverter.ToBitmap(mat);
                            PB2.Image = BitmapConverter.ToBitmap(mat2);
                        }
                    }
                }
            }
        }

        private void VideoCallback()
        {
            isVideoOn = true;
            Invoke((MethodInvoker)delegate { BT1.Text = "Running"; });

            while (true)
            {
                if (cap.Get(VideoCaptureProperties.PosFrames) == cap.Get(VideoCaptureProperties.FrameCount))
                {
                    msg(String.Format("Finished video"));
                    break;
                }
                else
                {
                    
                    try
                    {
                        cap.Read(mat);
                        if (!mat.Empty()) PB1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat);
                        Thread.Sleep(delay);
                    }
                    catch(Exception e)
                    {
                        // BUG - Total frame is different current frame. So, video do not stop normally.
                        // BUG - or video file is something wrong
                        StopVideo();
                    }
                }
            }
        }

        private void StopVideo()
        {
            // BUG - After stop, video do not play again
            ThreadVideo.Abort();
            cap.Release();
            mat.Release();
            isVideoOn = false;
            Invoke((MethodInvoker)delegate { BT1.Text = "Load File"; });
            msg(String.Format("Finished video"));            
        }

        private void BT2_Click(object sender, EventArgs e)
        {
            if(isCamOn)
            {
                if (cap.IsOpened())
                {
                    ThreadCam.Abort();
                    if (PB1.Image != null) PB1.Image.Dispose();
                    cap.Release();
                    mat.Release();
                    isCamOn = false;
                    Invoke((MethodInvoker)delegate { BT2.Text = "Open CAM"; });
                    msg(String.Format("Stopped CAM"));
                }
            }
            else
            {
                ThreadCam = new Thread(new ThreadStart(CameraCallback));
                ThreadCam.Start();                
            }
        }

        private void CameraCallback()
        {
            mat = new Mat();
            cap = new VideoCapture(0);
           
            if (!cap.IsOpened()) { msg("Can't open CAM"); return; }
            isCamOn = true;
            Invoke((MethodInvoker)delegate { BT2.Text = "Running"; });
            
            msg(String.Format("Start CAM - Width:{0} Height:{1}", cap.FrameWidth, cap.FrameHeight));
            msg(String.Format("FS : {0}", cap.Fps)); // In CAM, FS is 0. In video file, FS is not 0.

            while (true)
            {
                cap.Read(mat);
                if(!mat.Empty()) PB1.Image = BitmapConverter.ToBitmap(mat);
            }
        }

        private void msg(String str)
        {
            Invoke((MethodInvoker)delegate { LS1.Items.Add(str); });            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ThreadCam != null && ThreadCam.IsAlive) ThreadCam.Abort();
            if (ThreadVideo != null && ThreadVideo.IsAlive) ThreadVideo.Abort();
            //if (cap.IsOpened() && cap != null) { cap.Release(); mat.Release(); }
        }
        
        private int power(int n)
        {
            if (n == 0) return 1;
            return power(n - 1) * 2; 
        }

        private void BT_CLOSE_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
