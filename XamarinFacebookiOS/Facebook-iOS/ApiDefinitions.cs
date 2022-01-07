using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace XamarinFacebookiOS
{
	// @interface FacebookiOS : NSObject
	[BaseType (typeof(NSObject))]
	interface FacebookiOS
	{
		// @property (nonatomic, strong, class) UIViewController * _Nullable CrrentUIViewController;
		[Static]
		[NullAllowed, Export ("CrrentUIViewController", ArgumentSemantic.Strong)]
		UIViewController CrrentUIViewController { get; set; }

		// +(void)initializeSDKWithAppID:(NSString * _Nonnull)appID dispName:(NSString * _Nonnull)dispName;
		[Static]
		[Export ("initializeSDKWithAppID:dispName:")]
		void InitializeSDKWithAppID (string appID, string dispName);

		// +(void)finishedLaunchingWithApplication:(UIApplication * _Nonnull)application options:(NSDictionary<UIApplicationLaunchOptionsKey,id> * _Nullable)options;
		[Static]
		[Export ("finishedLaunchingWithApplication:options:")]
		void FinishedLaunchingWithApplication (UIApplication application, [NullAllowed] NSDictionary<NSString, NSObject> options);

		// +(void)openUrlWithApplication:(UIApplication * _Nonnull)application url:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nonnull)sourceApplication options:(NSDictionary * _Nullable)options;
		[Static]
		[Export ("openUrlWithApplication:url:sourceApplication:options:")]
		void OpenUrlWithApplication (UIApplication application, NSUrl url, string sourceApplication, [NullAllowed] NSDictionary options);
	}

	// @interface FacebookiOSAccessToken : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface FacebookiOSAccessToken
	{
		// @property (copy, nonatomic) NSString * _Nonnull tokenString;
		[Export ("tokenString")]
		string TokenString { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull permissions;
		[Export ("permissions", ArgumentSemantic.Copy)]
		string[] Permissions { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull declinedPermissions;
		[Export ("declinedPermissions", ArgumentSemantic.Copy)]
		string[] DeclinedPermissions { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull expiredPermissions;
		[Export ("expiredPermissions", ArgumentSemantic.Copy)]
		string[] ExpiredPermissions { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable expirationDate;
		[NullAllowed, Export ("expirationDate", ArgumentSemantic.Copy)]
		NSDate ExpirationDate { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable refreshDate;
		[NullAllowed, Export ("refreshDate", ArgumentSemantic.Copy)]
		NSDate RefreshDate { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable dataAccessExpirationDate;
		[NullAllowed, Export ("dataAccessExpirationDate", ArgumentSemantic.Copy)]
		NSDate DataAccessExpirationDate { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull appID;
		[Export ("appID")]
		string AppID { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull userID;
		[Export ("userID")]
		string UserID { get; set; }

		// -(instancetype _Nonnull)initWithTokenString:(NSString * _Nonnull)tokenString permissions:(NSArray<NSString *> * _Nonnull)permissions declinedPermissions:(NSArray<NSString *> * _Nonnull)declinedPermissions expiredPermissions:(NSArray<NSString *> * _Nonnull)expiredPermissions appID:(NSString * _Nonnull)appID userID:(NSString * _Nonnull)userID expirationDate:(NSDate * _Nullable)expirationDate refreshDate:(NSDate * _Nullable)refreshDate dataAccessExpirationDate:(NSDate * _Nullable)dataAccessExpirationDate;
		[Export ("initWithTokenString:permissions:declinedPermissions:expiredPermissions:appID:userID:expirationDate:refreshDate:dataAccessExpirationDate:")]
		IntPtr Constructor (string tokenString, string[] permissions, string[] declinedPermissions, string[] expiredPermissions, string appID, string userID, [NullAllowed] NSDate expirationDate, [NullAllowed] NSDate refreshDate, [NullAllowed] NSDate dataAccessExpirationDate);

		// -(instancetype _Nonnull)initWithTokenString:(NSString * _Nonnull)tokenString permissions:(NSArray<NSString *> * _Nonnull)permissions declinedPermissions:(NSArray<NSString *> * _Nonnull)declinedPermissions expiredPermissions:(NSArray<NSString *> * _Nonnull)expiredPermissions appID:(NSString * _Nonnull)appID userID:(NSString * _Nonnull)userID __attribute__((objc_designated_initializer));
		[Export ("initWithTokenString:permissions:declinedPermissions:expiredPermissions:appID:userID:")]
		[DesignatedInitializer]
		IntPtr Constructor (string tokenString, string[] permissions, string[] declinedPermissions, string[] expiredPermissions, string appID, string userID);
	}

	// @interface FacebookiOSEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface FacebookiOSEvents
	{
		// @property (nonatomic, class) BOOL isAutoLogAppEventsEnabled;
		[Static]
		[Export ("isAutoLogAppEventsEnabled")]
		bool IsAutoLogAppEventsEnabled { get; set; }

		// @property (nonatomic, class) BOOL isAdvertiserIDCollectionEnabled;
		[Static]
		[Export ("isAdvertiserIDCollectionEnabled")]
		bool IsAdvertiserIDCollectionEnabled { get; set; }

		// +(void)setEnableUpdatesOnAccessTokenChangeWithValue:(BOOL)value;
		[Static]
		[Export ("setEnableUpdatesOnAccessTokenChangeWithValue:")]
		void SetEnableUpdatesOnAccessTokenChangeWithValue (bool value);

		// +(void)activateAppEvents;
		[Static]
		[Export ("activateAppEvents")]
		void ActivateAppEvents ();

		// +(void)logEventWithEventName:(NSString * _Nonnull)eventName;
		[Static]
		[Export ("logEventWithEventName:")]
		void LogEventWithEventName (string eventName);

		// +(void)logEventWithEventName:(NSString * _Nonnull)eventName params:(NSDictionary * _Nonnull)params;
		[Static]
		[Export ("logEventWithEventName:params:")]
		void LogEventWithEventName (string eventName, NSDictionary @params);

		// +(void)logEventWithEventName:(NSString * _Nonnull)eventName valueToSum:(double)valueToSum;
		[Static]
		[Export ("logEventWithEventName:valueToSum:")]
		void LogEventWithEventName (string eventName, double valueToSum);

		// +(void)logEventWithEventName:(NSString * _Nonnull)eventName valueToSum:(double)valueToSum params:(NSDictionary * _Nonnull)params;
		[Static]
		[Export ("logEventWithEventName:valueToSum:params:")]
		void LogEventWithEventName (string eventName, double valueToSum, NSDictionary @params);

		// +(void)logEventWithEventName:(NSString * _Nonnull)eventName valueToSum:(NSNumber * _Nullable)valueToSum params:(NSDictionary * _Nonnull)params accessToken:(FacebookiOSAccessToken * _Nonnull)accessToken;
		[Static]
		[Export ("logEventWithEventName:valueToSum:params:accessToken:")]
		void LogEventWithEventName (string eventName, [NullAllowed] NSNumber valueToSum, NSDictionary @params, FacebookiOSAccessToken accessToken);
	}

	// @interface FacebookiOSLogin : NSObject
	[BaseType (typeof(NSObject))]
	interface FacebookiOSLogin
	{
		// @property (nonatomic, class) BOOL isCanceled;
		[Static]
		[Export ("isCanceled")]
		bool IsCanceled { get; set; }

		// @property (nonatomic, strong, class) FacebookiOSAccessToken * _Nullable currentAccessToken;
		[Static]
		[NullAllowed, Export ("currentAccessToken", ArgumentSemantic.Strong)]
		FacebookiOSAccessToken CurrentAccessToken { get; set; }

		// +(void)loginWithPermissions:(NSArray<NSString *> * _Nonnull)permissions onCompleted:(void (^ _Nonnull)(FacebookiOSAccessToken * _Nullable, NSError * _Nullable))onCompleted;
		[Static]
		[Export ("loginWithPermissions:onCompleted:")]
		void LoginWithPermissions (string[] permissions, Action<FacebookiOSAccessToken, NSError> onCompleted);

		// +(void)logout;
		[Static]
		[Export ("logout")]
		void Logout ();

		// +(void)getInfoWithParameters:(NSArray<NSString *> * _Nonnull)parameters onCompleted:(void (^ _Nonnull)(id _Nullable, NSError * _Nullable))onCompleted;
		[Static]
		[Export ("getInfoWithParameters:onCompleted:")]
		void GetInfoWithParameters (string[] parameters, Action<NSObject, NSError> onCompleted);

		// +(void)refreshAccessTokenOnCompleted:(void (^ _Nonnull)(FacebookiOSAccessToken * _Nullable, NSError * _Nullable))onCompleted;
		[Static]
		[Export ("refreshAccessTokenOnCompleted:")]
		void RefreshAccessTokenOnCompleted (Action<FacebookiOSAccessToken, NSError> onCompleted);
	}
}
