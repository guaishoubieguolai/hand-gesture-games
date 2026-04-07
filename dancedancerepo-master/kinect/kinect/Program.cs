using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.Kinect;

namespace kinect
{
    class Program
    {
        static void Main(string[] args)
        {
            KinectSensor sensor = KinectSensor.GetDefault();
            sensor.Open();
            
            Console.WriteLine("Stand on the left and right arrows, facing forward.\n");

            KinectCalibrator calibrator = new KinectCalibrator();

            Debug.WriteLine("Left/Right: {0}", DateTime.Now);

            CameraSpacePoint leftArrow = calibrator.LeftFoot;
            CameraSpacePoint rightArrow = calibrator.RightFoot;
            DepthSpacePoint leftDepth = sensor.CoordinateMapper.MapCameraPointToDepthSpace(leftArrow);
            DepthSpacePoint rightDepth = sensor.CoordinateMapper.MapCameraPointToDepthSpace(rightArrow);
            Console.WriteLine("Left Arrow: X:{0}, Y:{1}, Z:{2}", leftArrow.X, leftArrow.Y, leftArrow.Z);
            Console.WriteLine("Right Arrow: X:{0}, Y:{1}, Z:{2}", rightArrow.X, rightArrow.Y, rightArrow.Z);
            
            Console.WriteLine("\nLeft + Right Calibrated!\n");
            Console.WriteLine("Turn 90 Degrees CW and stand on the up and down arrows.");

            Thread.Sleep(2500);
            
            calibrator = new KinectCalibrator();

            Debug.WriteLine("Up/Down: {0}", DateTime.Now);

            CameraSpacePoint upArrow = calibrator.LeftFoot;
            CameraSpacePoint downArrow = calibrator.RightFoot;
            DepthSpacePoint upDepth = sensor.CoordinateMapper.MapCameraPointToDepthSpace(upArrow);
            DepthSpacePoint downDepth = sensor.CoordinateMapper.MapCameraPointToDepthSpace(downArrow);
            Console.WriteLine("Up Arrow: X:{0}, Y:{1}, Z:{2}", upArrow.X, upArrow.Y, upArrow.Z);
            Console.WriteLine("Right Foot: X:{0}, Y:{1}, Z:{2}", downArrow.X, downArrow.Y, downArrow.Z);

            Console.WriteLine("\nUp + Down Calibrated!\n");

            CameraSpacePoint center = KinectHelper.Average2CameraSpacePoints(upArrow, rightArrow);
            center = KinectHelper.Average2CameraSpacePoints(center, downArrow, 3);
            center = KinectHelper.Average2CameraSpacePoints(center, leftArrow, 4);
            DepthSpacePoint centerDepth = sensor.CoordinateMapper.MapCameraPointToDepthSpace(center);

            KinectDriver driver = new KinectDriver(upArrow, rightArrow, downArrow, leftArrow, calibrator.BodyFrameReader);
            driver.Start();
        }
    }
}
