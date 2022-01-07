//
//  FacebookiOS.Events.swift
//  Facebook-ios
//
//  Created by mohammad on 06/01/2022.
//

import Foundation
import FBSDKCoreKit

@objc(FacebookiOSEvents)
public class FacebookiOSEvents : NSObject{
    
    @objc public static var isAutoLogAppEventsEnabled: Bool {
        get{
            return Settings.shared.isAutoLogAppEventsEnabled
        }
        set{
            Settings.shared.isAutoLogAppEventsEnabled = newValue
        }
    }
    
    @objc public static var isAdvertiserIDCollectionEnabled: Bool {
        get{
            return Settings.shared.isAdvertiserIDCollectionEnabled
        }
        set{
            Settings.shared.isAdvertiserIDCollectionEnabled = newValue
        }
    }
    
    @objc
    public static func setEnableUpdatesOnAccessTokenChange(value: Bool) -> Void{
         Profile.enableUpdatesOnAccessTokenChange(value)
    }
    
    @objc
    public static func activateAppEvents() -> Void{
        AppEvents.shared.activateApp()
    }
    
    @objc
    public static func logEvent(eventName: String) -> Void{
        AppEvents.shared.logEvent(AppEvents.Name(rawValue: eventName))
    }
    
    @objc
    public static func logEvent(eventName: String,params: NSDictionary) -> Void{
        AppEvents.shared.logEvent(AppEvents.Name(rawValue: eventName), parameters: (params as! [AppEvents.ParameterName : Any]))
    }
    
    @objc
    public static func logEvent(eventName: String,valueToSum: Double) -> Void{
        AppEvents.shared.logEvent(AppEvents.Name(rawValue: eventName), valueToSum: valueToSum)
    }
    
    @objc
    public static func logEvent(eventName: String, valueToSum: Double, params: NSDictionary) -> Void{
        AppEvents.shared.logEvent(AppEvents.Name(rawValue: eventName), valueToSum: valueToSum, parameters: (params as! [AppEvents.ParameterName : Any]))
    }
    
    @objc
    public static func logEvent(eventName: String, valueToSum: NSNumber?, params: NSDictionary, accessToken: FacebookiOSAccessToken) -> Void{
        AppEvents.shared.logEvent(AppEvents.Name(rawValue: eventName), valueToSum: valueToSum, parameters: (params as! [AppEvents.ParameterName : Any]), accessToken: accessToken.toFBSDKAT())
    }
}
