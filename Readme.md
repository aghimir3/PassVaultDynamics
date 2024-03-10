# PassVault Dynamics

## About
PassVault Dynamics is a web application designed to allow users to securely change their Active Directory (AD) passwords from anywhere, at any time. Built using ASP.NET Core 6.0, it offers a user-friendly interface for users to update their AD credentials with ease, enhancing security and convenience.

## Features
- Secure Active Directory password change
- User-friendly interface
- 24/7 access from any web-enabled device

## Prerequisites
Before you begin, ensure you have met the following requirements:
- .NET 6.0 SDK installed
- Access to an Active Directory domain
- Web server (e.g., IIS) configured to host .NET applications
- Sufficient permissions to manage user accounts in Active Directory

## How to Compile
To compile PassVault Dynamics, follow these steps:

1. Clone the repository to your local machine:
   ```
   git clone https://github.com/aghimir3/PassVaultDynamics.git
   ```
2. Navigate to the project directory:
   ```
   cd PassVaultDynamics
   ```

3. Compile the project using the .NET CLI:
   ```
   dotnet build
   ```
   This will build the project, using the restored NuGet packages.

## Hosting on a Web Server
### Preparing for Deployment
1. Publish the application:
   ```
   dotnet publish -c Release -o ./publish
   ```
   This command compiles the application and places the publishable output in the `./publish` directory.

2. Prepare the published files for deployment to your web server.

### Configuring IIS
1. Install the .NET Hosting Bundle for .NET 6.0 if not already installed on your server.
2. In IIS Manager, create a new website or application pointing to the published application directory.
3. Configure the application pool to use No Managed Code since Kestrel handles the runtime.
4. Ensure the IIS server is properly joined to the domain to allow AD operations.
5. Set the necessary permissions for the application pool identity to interact with Active Directory.

### Configuring the Application
1. Configure the `ShowLogo` setting in `appsettings.json` to control the visibility of your company logo in the application. Set `ShowLogo` to `true` and provide the `FilePath` under the `Logo` configuration to display the logo. For example:
   ```json
   {
     "Logo": {
       "ShowLogo": true,
       "FilePath": "path/to/your/logo.png"
     }
   }
   ```
2. Ensure that the server's firewall and security settings allow the necessary traffic for users to access the application.

### Using the GitHub Release to Host on IIS
1. Download the latest release from the GitHub repository's Releases page.
2. Extract the downloaded ZIP file to your desired location on the IIS server.
3. In IIS Manager, create a new website or application pointing to the extracted application directory.
4. Configure the application pool to use No Managed Code since Kestrel handles the runtime.
5. Ensure the IIS server is properly joined to the domain to allow AD operations.
6. Set the necessary permissions for the application pool identity to interact with Active Directory.
7. Access the application through the configured URL on your web browser.

## Usage
- Users navigate to the application using their web browser.
- They are presented with a form to enter their current AD username, current password, and new password.
- Upon submission, the application validates and applies the password change in Active Directory.

## Contributing
Contributions to PassVault Dynamics are welcome. Please follow the standard pull request process to propose changes.

## License
PassVault Dynamics is open-source software licensed under the MIT License. See the LICENSE file for more information.
