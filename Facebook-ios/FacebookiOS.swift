//
//  FacebookiOS.swift
//  Facebook-ios
//
//  Created by mohammad on 04/01/2022.
//

import Foundation
import UIKit
import FBSDKCoreKit


@objc(FacebookiOS)
public class FacebookiOS : NSObject
{
    @objc
    public static var CrrentUIViewController: UIViewController?
    
    @objc
    public static func initializeSDK(appID: String, dispName: String) -> Void {
        Settings.shared.appID = appID
        Settings.shared.displayName = dispName
    }
    
    @objc
    public static func finishedLaunching(application: UIApplication, options: [UIApplication.LaunchOptionsKey: Any]? = nil) -> Void {
        ApplicationDelegate.shared.application(application, didFinishLaunchingWithOptions: options)
    }
    
    @objc
    public static func openUrl(application: UIApplication, url: NSURL, sourceApplication: String, options: NSDictionary? = nil) -> Void {
        var op: Any? = options
        if op == nil{
            op = [UIApplication.OpenURLOptionsKey.annotation]
        }
            
        ApplicationDelegate.shared.application(application, open: url as URL, sourceApplication: sourceApplication, annotation: op)
    }
}
