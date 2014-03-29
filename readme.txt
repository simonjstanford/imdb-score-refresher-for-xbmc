Searches a local Sqlite or remote MySQL XBMC databases and refreshes film IMDB scores.  It is fully tested with Frodo.  

Unfortunately this doesn't work with TV episodes, but there only seems to be a few hundred votes per individual episode so is probably not worth the effort.

==FAQ==

*What is the username and password for the databases?*

The local .db file doesn't need a password, but the username and password for the shared library is normally ‘xbmc’.

*What is the database name? 

The remote database name for XBMC is currently myvideos75. However, this does change when different versions of XBMC are released. 
Those not using a Windows server may need to capitalise the database name, e.g. 'MyVideos75'. 

*Do I need to install anything else for this app to work?*

No - the DLLs for MySQL and Sqlite have been included in the download, so nothing else is required.

==Changelog==

1.0 - Local Sqlite database support added for movies
    - Remote MySQL database support added for movies

2.1 - Much better error handling - this version should not freeze at all
    - Transfer of app to .net 4
    - Minor bug fixes

2.5 - Implemented scraper for IMDB website. Now scores are retrieved directly from IMDB instead of via a web service.
    - Error log added