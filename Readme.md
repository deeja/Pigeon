#Pigeon Sitecore Log Emailer

##How Pigeon works
Either through a scheduled task, or clicking the button, a email is sent containing the zipped logs from a defined period.

##Why is Pigeon beneficial
If running multiple servers, such as CD servers, it can be difficult to access the log files. If they are difficult to access, then they are often neglected. 
By having the files send to a central location, they are easily managed.

If you do not have access to the servers at all, then Pigeon might be the only option.

##Why not use an exception tracking tool?
You totally should be using an exception / error tracking tool; there are many online with most offering something for free.
This is a _complimentary_ system. 

##Pigeon is not a log manager
i.e. i.e. No zipping or deletion of logs
The deletion or zipping of logs is part of log management. This should be handled by a clean up task, or manually. 
Pigeon is staying away from both of these tasks. Pigeon zips to a temp file, then posts that temp file, then deletes it. That's all.