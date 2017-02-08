##Notes 
### Remote Events
Execute on cd server via remote event

###Scheduled task
Click button or scheduled task

- get logs for today
- get logs for yesterday
- run per day
- configure email from
- configure email to

###Email

Test email? - No, can test by clicking send logs button.
If no logs, send email with message - 0 Logs

### Log stats
Future - Could add stats for showing how many files are in the logs, as well as the size of the log folder

##Development Plan

###Start Job
Add button
Add scheduler
- out: start job
- out: email address
- out: date range


###Find files
Look for files with a pattern
- in:date pattern
- in:date range
- out:file names

###Zip files
Take provided filenames 
Add files to temp zip file 
- in: file names DONE 
- in: -output file name- (uses a stream)
- out: single zip (as stream) DONE
- out: list of log files contained in the zip and sizes DONE


###Send files 
Add file to mail
Send to email 
in: log stats (DONE)
in: attachment name (DONE)
in: zip file (DONE)
in: email address (DONE)
out: email message with attached file, list of log files -and sizes- (DONE)




