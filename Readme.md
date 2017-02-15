#Pigeon Sitecore Log (and More) Emailer

##How Pigeon works
Either through a scheduled task, or clicking the button, a email is sent containing the zipped logs from a defined period.

## The "And More" bit
Pigeon has a pipeline that can be extended to include other files in the final zip. The pipeline can also be modified to:

- Swap out the mailer to change the way the message is delived (Event Message Queue?)
- Add (or remove) files to list that are zipped and sent.
- Extend the zipper to use a password or private key

##Why is Pigeon beneficial
If running multiple servers, such as CD servers, it can be difficult to access the log files. If they are difficult to access, then they are often neglected. 
By having the files send to a central location, they are easily managed.

If you do not have access to the servers at all, then Pigeon might be the only option.

##Why not use an exception tracking tool?
You totally should be using an exception / error tracking tool; there are many online with most offering something for free.
This is a _complimentary_ system. 

##Pigeon is not a log manager
i.e. No zipping or deletion of logs
The deletion or zipping of logs is part of log management. This should be handled by a clean up task, or manually. 
Pigeon is staying away from both of these tasks. Pigeon zips to a temp file, then posts that temp file, then deletes it. That's all.

##Configuration
There are two settings that must be overridden from the config:
```
      <setting name="Pigeon.Email.To" value="setme@example.com" />
      <setting name="Pigeon.Email.From" value="setme@example.com" />
```

There is an example file called Pigeon.Override.config.example that can used as the base for this override.

##Use
After installation, enable the Developer Toolbar in the content editor (right click main toolbar to select Developer Toolbar).
You can choose from the options there. 

There is also a scheduled task that can be enabled by changing the end date to a point in the future. 
`/sitecore/system/Tasks/Schedules/Pigeon/Pigeon Yesterdays Logs`

##Installation
### Basic installation on Content Management and Delivery servers
Look under the releases for the install package https://github.com/deeja/Pigeon/releases 
There is a Content Delivery version provided as a Nuget package. This should be compatible with Octopus Deploy or your own projects.

### Installing for development purposes
1. Set the unicorn serialisation folder to the correct location. This is done in the _Unicorn.CustomSerializationFolder.config_ file. It should point to the Unicorn folder in the root of this Solution. e.g C:\projects\Pigeon\Unicorn\$(configurationName)
2. Publish Pigeon.Web to your sitecore instance (right click -> Publish). If debugging, make sure you select _Debug_ and not _Release_. 
3. Run the Unicorn Sync [site]/Unicorn.aspx
4. Modify the Pigeon.Override.Config.example settings to match your server's settings

##Building the packages
### Sitecore package
There is a file called Pigeon.package that can be opened in Visual Studio with Sitecore Rocks. 
1. Publish the web project to a local site
2. Click "Build" on the Pigeon.package toolbar

### CD Server Nuget package
1. Run _nuget pack Pigeon-CD.nuspec -Version 1.0.0_

