using System; 
using WebMatrix.WebData; 
using WebMatrix.Data;

/// <summary> 
/// Class provides static methods to 
/// </summary> 
public class WebSecurityExt 
{ 
    /// <summary> 
    /// Gets whether the current user is listed as an admin in the roles table. 
    /// </summary> 
    /// <returns>true if the current user id has Role ID = 1 in the 
    /// webpages_UsersInRole table, otherwise false.</returns> 
    static public bool IsAdmin 
    { 
        get 
        { 
            // get the current user ID 
            int userID = WebSecurity.CurrentUserId; 
            
            if (userID == -1) 
            { 
                // if the user does not exist, return not admin 
                return false; 
            }

            // see if the user matches the RoleID you have for Admin 
            var db = Database.Open("StarterSite"); 
            var SQLSELECT = "SELECT RoleID FROM webpages_UsersInRoles" + "WHERE UserID=@0"; 
            var UserInRole = db.QuerySingle(SQLSELECT, userID); 
            if (UserInRole.RoleID == 1) 
            { 
                return true; 
            } 
            else 
            { 
                return false; 
            } 
        } 
    } 
}