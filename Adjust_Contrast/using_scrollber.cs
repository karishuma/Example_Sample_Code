using System;
using OpenCvSharp;
using OpenCvSharp.Extensions;

public partial class Form1 : Form
{
    Mat mat;

    public Form1()
    {
        InitializeComponent();

        PB1.SizeMode = PictureBoxSizeMode.StretchImage;
        PB2.SizeMode = PictureBoxSizeMode.StretchImage;

        vScrolContrast.Value = 100;
        vScrolContrast.Minimum = 0;
        vScrolContrast.Maximum = 200;
    }

    private void BT1_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            mat = Cv2.ImRead(dlg.FileName, ImreadModes.Grayscale);
            Mat dst = new Mat();
            dst = mat;

            PB1.Image = BitmapConverter.ToBitmap(mat);
            PB2.Image = BitmapConverter.ToBitmap(dst);
        }
    }

    private void vScrolContrast_Scroll(object sender, ScrollEventArgs e)
    {
        float alpha = (float)1.0;
        float step = (float)0.05;
        if (vScrolContrast.Value > 100) alpha = (vScrolContrast.Value - 100) * step; // down direction from center of scroll bar
        else alpha = ((100 - vScrolContrast.Value) * step) * (-1); // up direction from center of scroll bar

        Mat dst = new Mat();
        dst = mat + ((mat - 128) * alpha);

        PB2.Image = BitmapConverter.ToBitmap(dst);
    }
}