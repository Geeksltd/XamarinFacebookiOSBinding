//
//  FacebookiOS.AccessToken.swift
//  Facebook-ios
//
//  Created by mohammad on 06/01/2022.
//

import Foundation
import FBSDKCoreKit

@objc(FacebookiOSAccessToken)
public class FacebookiOSAccessToken : NSObject{
    @objc public final var tokenString: String
    @objc public final var permissions: [String]
    @objc public final var declinedPermissions: [String]
    @objc public final var expiredPermissions: [String]
    @objc public final var expirationDate: Date?
    @objc public final var refreshDate: Date?
    @objc public final var dataAccessExpirationDate: Date?
    @objc public final var appID: String
    @objc public final var userID: String
    
    @objc
    public convenience init(tokenString: String, permissions: [String], declinedPermissions: [String], expiredPermissions: [String], appID: String, userID: String, expirationDate: Date?, refreshDate: Date?, dataAccessExpirationDate: Date?){
        self.init(tokenString: tokenString, permissions: permissions, declinedPermissions: declinedPermissions, expiredPermissions: expiredPermissions, appID: appID, userID: userID)
        self.expirationDate = expirationDate
        self.refreshDate = refreshDate
        self.dataAccessExpirationDate = dataAccessExpirationDate
    }
    
    @objc
    public init(tokenString: String, permissions: [String], declinedPermissions: [String], expiredPermissions: [String], appID: String, userID: String){
        self.tokenString = tokenString
        self.permissions = permissions
        self.declinedPermissions = declinedPermissions
        self.expiredPermissions = expiredPermissions
        self.appID = appID
        self.userID = userID
    }
    
    public func toFBSDKAT() -> AccessToken{
        return AccessToken(tokenString: self.tokenString, permissions: self.permissions, declinedPermissions: self.declinedPermissions, expiredPermissions: self.expiredPermissions, appID: self.appID, userID: self.userID, expirationDate: self.expirationDate, refreshDate: self.refreshDate, dataAccessExpirationDate: self.dataAccessExpirationDate)
    }
    
    public static func fromFBSDKAT(accessToken: AccessToken, permissions: [String], declinedPermissions: [String], expiredPermissions: [String]) -> FacebookiOSAccessToken {
        return FacebookiOSAccessToken(tokenString: accessToken.tokenString, permissions: permissions, declinedPermissions: declinedPermissions, expiredPermissions: expiredPermissions, appID: accessToken.appID, userID: accessToken.userID, expirationDate: accessToken.expirationDate, refreshDate: accessToken.refreshDate, dataAccessExpirationDate: accessToken.dataAccessExpirationDate)
    }
}
