# Acme-Corp

Acme corp is a web application that allows consumers of their products, to get a serial number, and use it to enter a draw (hopefully for some prizes)
This project can make serial numbers, recieve forms, and check the forms for certain draw rules, like you can't enter a draw more than twice with the same serial number.

## Prerequisites

* You have installed the latest version of ASP.net 3.1

## Installing Acme-Corp

```
Download the project.
Open it in Visual Studio Code/ Visual Studio

```

## Using Acme-Corp

To use Acme-Corp, follow these steps:

```
1. Launch the application and go to Account/Register
2. Make an account
3. Close the application
3. Open up the AcmeCorp_Identity database, and view the table dbo.AspNetRoles
4. Type "1" under Id(or whatever Id you desire) And "Admin" under Name, now you've established an admin role! Time to make yourself an admin.
5. View the table dbo.Users, and copy your Id. 
6. View the table dbo.AspNetUserRoles and paste in your Id in the "UserId" coloumn, and type "1" under RoleId(Or whatever Id you chose, in step 3)
7. Launch the application and go to Account/Login, login to your account, if already logged in, log out, then log in.
8. You're now an admin and have acces to all the features!
9. Click the "Create Serialnumbers" link in the top, or go to Forms/CreateNumbers and type in however many serial numbers you'd like to make.
10. You can now start to make forms by clicking the "Draw" link, or going to Form/Create, and the project should be up and running!
```

