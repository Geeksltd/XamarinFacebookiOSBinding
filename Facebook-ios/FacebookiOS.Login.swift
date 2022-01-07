//
//  FacebookiOS.Login.swift
//  Facebook-ios
//
//  Created by mohammad on 06/01/2022.
//

import Foundation
import FBSDKLoginKit

@objc(FacebookiOSLogin)
public class FacebookiOSLogin : NSObject
{
    @objc public static var isCanceled: Bool = false
    @objc public static var currentAccessToken: FacebookiOSAccessToken?
    static var currentPermissions: [String]?
    static var loginManager: LoginManager?
    
    @objc
    public static func login(permissions: [String],onCompleted: @escaping (FacebookiOSAccessToken?, Error?) -> Void) -> Void {
        currentPermissions = permissions
        loginManager = LoginManager()
        loginManager!.logIn(permissions: permissions, from: FacebookiOS.CrrentUIViewController){ result, error in
            if let error = error {
                onCompleted(nil, error)
            } else if let result = result ,result.isCancelled{
                isCanceled = true
            }else{
                let accessToken = result!.token!
                if (accessToken.isExpired){
                    refreshAccessToken(){ token, error in
                        if let error = error {
                            onCompleted(nil, error)
                        }else{
                            let accessToken = token!
                            onCompleted(accessToken, nil)
                        }
                    }
                }else{
                    onCompleted(FacebookiOSAccessToken.fromFBSDKAT(accessToken: accessToken, permissions: currentPermissions!, declinedPermissions: [String](), expiredPermissions: [String]()), nil)
                }
            }
        }
    }
    
    @objc
    public static func logout() -> Void{
        loginManager?.logOut()
        currentAccessToken = nil
    }
    
    @objc
    public static func getInfo(parameters: [String], onCompleted: @escaping (Any?,Error?) -> Void) -> Void {
        refreshAccessToken(){result, error in
            if let error = error {
                onCompleted(nil, error)
            }else{
                let token = result!.tokenString
                let param = NSDictionary.init(object: parameters.joined(separator: ","), forKey: "fields" as NSCopying)
                GraphRequest(graphPath: "me", parameters: param as! [String : Any], tokenString: token, version: nil, httpMethod: HTTPMethod(rawValue: "GET")).start(){connection,data, error in
                    if let data = data{
                        onCompleted(data, nil)
                    }else{
                        onCompleted(nil, error)
                    }
                }
            }
        }
    }
    
    @objc
    public static func refreshAccessToken(onCompleted: @escaping (FacebookiOSAccessToken?, Error?) -> Void) -> Void {
        let token = AccessToken.current
        if (token == nil || token!.isExpired){
            AccessToken.refreshCurrentAccessToken(){ gc, result, err in
                if let error = err {
                    onCompleted(nil, error)
                } else{
                    let accessToken = FacebookiOSAccessToken.fromFBSDKAT(accessToken: result as! AccessToken, permissions: currentPermissions!, declinedPermissions: [String](), expiredPermissions: [String]())
                    onCompleted(accessToken, nil)
                }
            }
        }
    }
}
