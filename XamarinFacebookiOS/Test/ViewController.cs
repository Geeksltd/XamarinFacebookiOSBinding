using Foundation;
using System;
using UIKit;

namespace Test
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            XamarinFacebookiOS.FacebookiOS.CrrentUIViewController = this;
            XamarinFacebookiOS.FacebookiOS.InitializeSDKWithAppID("key", "title");


            var btn = new UIButton(new CoreGraphics.CGRect(10,10,100,50));
            btn.SetTitle("Login", UIControlState.Application);
            btn.AddTarget((s, e) =>
            {
                XamarinFacebookiOS.FacebookiOSLogin.LoginWithPermissions(new[] { "public_profile", "email" }, (token, error1) =>
                {
                    if (error1 != null)
                    {
                        //error happens
                    }
                    else
                    {
                        //use token
                        XamarinFacebookiOS.FacebookiOSLogin.GetInfoWithParameters(new[] { "First_name", "Last_name" }, (result, error2) =>
                        {
                            if (error2 != null)
                            {
                                //error happens
                            }
                            else
                            {
                                //use result
                            }
                        });
                    }

                });
            }, UIControlEvent.TouchUpInside);

            Add(btn);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
