using System;
using Microsoft.Kinect;

namespace kinect
{
    class KinectCalibrator
    {
        private BodyFrameReader bodyReader;
        private Body skeleton;
        
        public CameraSpacePoint LeftFoot { get; private set; }
        public CameraSpacePoint RightFoot { get; private set; }
        public CameraSpacePoint Center { get; private set; }

        public KinectCalibrator()
        {
            KinectSensor sensor = KinectSensor.GetDefault();
            bodyReader = sensor.BodyFrameSource.OpenReader();
            
            bool calibrated = false;
            while (!calibrated)
            {
                using (var frame = bodyReader.AcquireLatestFrame())
                {
                    if (frame != null)
                    {
                        Body[] bodies = new Body[frame.BodyCount];
                        frame.GetAndRefreshBodyData(bodies);
                        
                        foreach (Body body in bodies)
                        {
                            if (body.IsTracked)
                            {
                                LeftFoot = body.Joints[JointType.FootLeft].Position;
                                RightFoot = body.Joints[JointType.FootRight].Position;
                                Center = KinectHelper.Average2CameraSpacePoints(LeftFoot, RightFoot);
                                calibrated = true;
                            }
                        }
                    }
                }
                System.Threading.Thread.Sleep(100);
            }
        }

        public BodyFrameReader BodyFrameReader
        {
            get { return bodyReader; }
        }
    }
}
