# uia-filelogger
This is a small application I made when I worked at the University og Agder, (UiA)

## Original
The original had to be de-compiled with ILSpy after a small "snafu", when my contract ended, and systems were purged. I had to re-add the delimon library, (I'm trying to find it's lisence so it might be inapropriate to incloude)

It ran thousands of times and only one reported crash, leading to me, looking over the code, testing, then shrugging, and it never happened again.

## Why this exist
In 2016, University of Agder, (UiA), was moving from Windows 7 to Windows 10. We needed a tool for logging files a user had possibly had used, (had access to).

The reason for this rests in Windows "offline files"-issues. One issues was that people had a limit of X amounts of file storage; this could be increased if it was sencible. People, being people, started working aorund the limit by storing data on "C:\\\\somedirectory\\". Also sometimes, certain application forced the storing of files to "C:\\\\users\\<username>\\Documents\\", which circumvented the users' redirected libraries, that were hosted in offline-files, (the Microsoft consultant had helped set up a configuration that made a user machine-independent, and so all "user-files" were synched ass offline-files).

Where this application came in handy was when employees, who, despite us helping, didn't transfere all his files to "synched" directory, was upset that their files were gone, and we could check the files and show, A that they didn't have those files on the computer, B where they actually were stored, or C where the files were and ask why they didn't inform us about the files' location.

As a side-noe, offline-files don't sync properly, and sometimes we came across users with tens of gigabytes of data that had to be manually copied, (we used treesize, and WinMerge).

## The future
I intend to re-make this into a .net core dll, with a Console Application using it, as it's actually useful for a custom file-search program, (I got the idea when being irritated by windows using minutes to dearch for a file-name)

### Funfacts:
##### Funfact 1 - The file access exception bug
One the of the features in this application is that it ignores files the user don't have access rights too, and that this is a bug in the .net framework that can't be fixed, (it is in .net core), because there are too many applications, using this bug to have more speed applications.

##### Funfact 2 - Filename and path workaround "bug"
Did you know that there is a hard limit too how long a filename or a path can be in Windows? Did you also know that Windows has workarounds for this, but It's a hack/bug?