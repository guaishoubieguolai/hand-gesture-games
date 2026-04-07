using System;
using Microsoft.Kinect;

namespace kinect
{
    class KinectHelper
    {
        public static CameraSpacePoint Average2CameraSpacePoints(CameraSpacePoint p1, CameraSpacePoint p2, int weight = 1)
        {
            return new CameraSpacePoint
            {
                X = (p1.X + p2.X * weight) / (1 + weight),
                Y = (p1.Y + p2.Y * weight) / (1 + weight),
                Z = (p1.Z + p2.Z * weight) / (1 + weight)
            };
        }
    }
}
