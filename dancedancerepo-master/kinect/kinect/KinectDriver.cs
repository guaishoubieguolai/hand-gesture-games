using System;
using System.IO.Ports;
using Microsoft.Kinect;

namespace kinect
{
    class KinectDriver
    {
        private SerialPort arduino;
        private CameraSpacePoint upArrow, rightArrow, downArrow, leftArrow;
        private BodyFrameReader bodyReader;

        public KinectDriver(CameraSpacePoint up, CameraSpacePoint right, CameraSpacePoint down, CameraSpacePoint left, BodyFrameReader reader)
        {
            upArrow = up;
            rightArrow = right;
            downArrow = down;
            leftArrow = left;
            bodyReader = reader;
            
            arduino = new SerialPort("COM3", 9600);
            arduino.Open();
        }

        public void Start()
        {
            while (true)
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
                                var leftFoot = body.Joints[JointType.FootLeft].Position;
                                var rightFoot = body.Joints[JointType.FootRight].Position;
                                
                                // Determine which arrow the player is on
                                string direction = DetermineDirection(leftFoot, rightFoot);
                                
                                if (!string.IsNullOrEmpty(direction))
                                {
                                    arduino.WriteLine(direction);
                                }
                            }
                        }
                    }
                }
                System.Threading.Thread.Sleep(50);
            }
        }

        private string DetermineDirection(CameraSpacePoint leftFoot, CameraSpacePoint rightFoot)
        {
            // Simplified direction detection logic
            return "UP"; // Placeholder
        }
    }
}
