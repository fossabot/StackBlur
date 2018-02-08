// Copyright (c) 2018 Victorique Ko
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace StackBlur.Test
{
    public class StackBlur_ProcessShould
    {
        private static bool IsEqual(Bitmap lhs, Bitmap rhs)
        {
            var lhsData = lhs.LockBits(new Rectangle(Point.Empty, lhs.Size),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var rhsData = rhs.LockBits(new Rectangle(Point.Empty, rhs.Size),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var lhsPixels = new byte[Math.Abs(lhsData.Stride) * lhsData.Height];
            var rhsPixels = new byte[Math.Abs(rhsData.Stride) * rhsData.Height];
            Marshal.Copy(lhsData.Scan0, lhsPixels, 0, lhsPixels.Length);
            Marshal.Copy(rhsData.Scan0, rhsPixels, 0, rhsPixels.Length);

            try
            {
                return lhsPixels.SequenceEqual(rhsPixels);
            }
            finally
            {
                lhs.UnlockBits(lhsData);
                rhs.UnlockBits(rhsData);
            }
        }

        [Theory]
        [InlineData("Images/0px.png", "Images/10px.png", 10)]
        [InlineData("Images/0px.png", "Images/20px.png", 20)]
        [InlineData("Images/0px.png", "Images/30px.png", 30)]
        [InlineData("Images/0px.png", "Images/40px.png", 40)]
        [InlineData("Images/0px.png", "Images/50px.png", 50)]
        public void ReturnBlurredImage(string filename, string expectedFilename, int radius)
        {
            var bitmap = new Bitmap(filename);
            var expectedBitmap = new Bitmap(expectedFilename);

            StackBlur.Process(bitmap, radius);

            Assert.True(IsEqual(bitmap, expectedBitmap));
        }
    }
}
