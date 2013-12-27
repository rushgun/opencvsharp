﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// Blob set
    /// </summary>
    public class CvBlobs : Dictionary<int, CvBlob>
    {
        /// <summary>
        /// Label values
        /// </summary>
        public LabelData Labels { get; protected set; }

        /// <summary>
        /// Constructor (init only)
        /// </summary>
        public CvBlobs()
        {
        }
        /// <summary>
        /// Constructor (init and cvLabel)
        /// </summary>
        /// <param name="img">Input binary image (depth=IPL_DEPTH_8U and nchannels=1).</param>
        public CvBlobs(IplImage img)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (img.Depth != BitDepth.U8 || img.NChannels != 1)
                throw new ArgumentException("img.Depth == BitDepth.U8 && img.NChannels == 1");

            Label(img);
        }

        #region Methods
        #region Label
        /// <summary>
        /// Label the connected parts of a binary image. (cvLabel)
        /// </summary>
        /// <param name="img">Input binary image (depth=IPL_DEPTH_8U and num. channels=1).</param>
        /// <returns>Number of pixels that has been labeled.</returns>
        public int Label(IplImage img)
        {
            if (img == null)
                throw new ArgumentNullException("img");

            Labels = new LabelData(img.Height, img.Width, img.ROI);
            return Labeller.Perform(img, this);
        }
        #endregion
        #region FilterLabels
        /// <summary>
        /// Draw a binary image with the blobs that have been given. (cvFilterLabels)
        /// </summary>
        /// <param name="imgOut">Output binary image (depth=IPL_DEPTH_8U and nchannels=1).</param>
        public void FilterLabels(IplImage imgOut)
        {
            CvBlobLib.FilterLabels(this, imgOut);
        }
        #endregion
        #region GreaterBlob
        /// <summary>
        /// Find greater blob. (cvGreaterBlob)
        /// </summary>
        /// <returns>Label of greater blob.</returns>
        public int GreaterBlob()
        {
            return CvBlobLib.GreaterBlob(this);
        }
        /// <summary>
        /// Find the largest blob. (cvGreaterBlob)
        /// </summary>
        /// <returns>Label of the largest blob.</returns>
        public int LargestBlob()
        {
            return CvBlobLib.GreaterBlob(this);
        }
        #endregion
        #region RenderBlobs
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        public void RenderBlobs(IplImage imgSource, IplImage imgDest)
        {
            CvBlobLib.RenderBlobs(this, imgSource, imgDest);
        }
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        public void RenderBlobs(IplImage imgSource, IplImage imgDest, RenderBlobsMode mode)
        {
            CvBlobLib.RenderBlobs(this, imgSource, imgDest, mode);
        }
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        /// <param name="alpha">If mode CV_BLOB_RENDER_COLOR is used. 1.0 indicates opaque and 0.0 translucent (1.0 by default).</param>
        public void RenderBlobs(IplImage imgSource, IplImage imgDest, RenderBlobsMode mode, Double alpha)
        {
            CvBlobLib.RenderBlobs(this, imgSource, imgDest, mode, alpha);
        }
        #endregion
        #region FilterByArea
        /// <summary>
        /// Filter blobs by area. 
        /// Those blobs whose areas are not in range will be erased from the input list of blobs. (cvFilterByArea)
        /// </summary>
        /// <param name="minArea">Minimun area.</param>
        /// <param name="maxArea">Maximun area.</param>
        public void FilterByArea(UInt32 minArea, UInt32 maxArea)
        {
            CvBlobLib.FilterByArea(this, minArea, maxArea);
        }
        #endregion
        #endregion
    }
}