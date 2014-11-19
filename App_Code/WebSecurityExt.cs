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
    static public string whatUser
    { 
        get 
        { 
            // get the current user ID 
            int userID = WebSecurity.CurrentUserId; 
            
            if (userID == -1) 
            { 
                // if the user does not exist, return not admin 
                return "notregistered"; 
            }

            // see if the user matches the RoleID you have for Admin 
            var db = Database.Open("StarterSite"); 
            var strSQL = String.Format("SELECT RoleID FROM webpages_UsersInRoles WHERE UserID={0}", userID);
            var UserInRole = db.QuerySingle(strSQL); 
            if(UserInRole.RoleID == 1)
            {
                return "admin";                
            }
            else if(UserInRole.RoleID == 2)
            { 
                return "user"; 
            }
            else { return "notregistered"; }
        } 
    } 
}