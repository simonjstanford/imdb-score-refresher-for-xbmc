# XBMC Film Score Refresher #


Searches a local [SQLite](http://www.sqlite.org) or remote [MySQL](http://www.mysql.com) [XBMC](http://xbmc.org/about/) databases and refreshes film [IMDB](http://www.imdb.com/) scores.  It is fully tested with XBMC 12.0 Frodo.  Unfortunately this doesn't work with TV episodes, but there is a few hundred votes per individual episode so the score is not accurate.

## FAQ ##

### What is the username and password for the databases? ###

The local .db file doesn't need a password, but the username and password for the shared 
library is normally ‘xbmc’.

### What is the database name? ###

The remote database name for XBMC is currently myvideos75. However, this does change when 
different versions of XBMC are released. Those not using a Windows server may need to 
capitalise the database name, e.g. 'MyVideos75'. 

### Do I need to install anything else for this app to work? ###

No - the DLLs for MySQL and Sqlite have been included in the download, so nothing else is 
required.

### Is this app compatible with XBMC 13.0 Gotham? ###

Yes - just change the database name to MyVideos78.

## Changelog ##

### 1.0 ###
- Local Sqlite database support added for movies
- Remote MySQL database support added for movies

### 2.1 ###
- Much better error handling - this version should not freeze at all
- Transfer of app to .net 4
- Minor bug fixes

### 2.5 ###
- Implemented scraper for IMDB website. Now scores are retrieved directly from IMDB instead of via a web service.
- Error log added