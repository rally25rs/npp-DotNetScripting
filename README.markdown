Notepad++ .NET Scripting Plugin
================================

This is a plugin for [Notepad++](http://notepad-plus-plus.org/) that provides
the ability to run C# and VB.NET code against open files in the text editor.

Lines of .NET code are run against each line of text, much like the unix "awk" utility.

The plugin allows the user to enter 3 blocks of C# or VB.NET code:

+ A script to run before each file.
+ A script to run for each individual line of each file.
+ A script to run at the end of each file.

The script can manipulate the line of text in Notepad++, and perform some basic actions.

Installing the DotNetScripting Plugin
--------------------------------------

Ensure that your computer has [the .NET 4 runtime](http://www.microsoft.com/download/en/details.aspx?id=17851) installed.

Ideally, the plugin should be installed through the Notepad++ Plugin Manager.

To manually install the plugin, copy the contents of:

> \bin\Debug\*

To your Notepad++ install location's plugins directory. For example:

> C:\Program Files (x86)\Notepad++\plugins

Technical Details
------------------

This plugin is written in C# and .NET 4.
There is also a C++ wrapper that loads the C# assembly.
This plugin uses the [Microsoft Roslyn CP](http://www.microsoft.com/download/en/details.aspx?id=27746#additional-information) project to execute the .NET scripts.

Usage
------

###Get and Set the current line of text.

In the script, the variable "_" (single underscore character) is a string, and is used to
represent the current line of text. Setting this variable to another value will cause the
line of text in the editor to be changed.

###Get "newline" character(s)

(not yet implemented)

###Delete curent line.

Setting the current line variable (_) to null will instruct the plugin to delete the current line.

> if(shouldDeleteThisLine)
>     _ = null;

###Bookmark current line.

(not yet implemented)

###Referencing additional assemblies (custom code, 3rd party utilities, web services, etc.)

(not yet implemented)

Usage Examples
---------------

###Double space all lines.

Text:

> one
> two
> three

Script (For Each Line):

> _ = _ + "\r\n";

Resulting Text:

> one
>
> two
> 
> three
>

###Prefix each line with a line number.

Text:

> one
> two
> three

Script (Before File):

> var x = 0;

Script (For Each Line):

> x++;
> _ = x + ": " + _;

Resulting Text:

> 1: one
> 2: two
> 3: three
