# FileUtil [![Build Status](https://travis-ci.org/NinjaRocks/FileUtil.svg?branch=master)](https://travis-ci.org/NinjaRocks/FileUtil) 
.Net Library to read from fixed width or delimiter separated file using strongly typed objects.


-------------


**Fixed Width or Delimiter Separated File** 
------------------------------------------------------------------------
> What is Fixed width or Delimiter separated text files?

Fixed width or Delimiter separeted text file is a file that has a specific format which allows for the manipulation of textual information in an organized fashion.  
Each row contains one record of information; each record can contain multiple pieces of data fields or columns. The data columns are separated by any character you specify called the delimiter. All rows in the file follow a consistent format and should be with the same number of data columns. Data columns could be empty with no value.

**CASE 1 :** Simple pipe '|' separated Delimeter File is shown below (this could even be comma ',' separated CSV)

    |Mr|Jack Marias|Male|London|Active|||
    |Dr|Bony Stringer|Male|New Jersey|Active||Paid|
    |Mrs|Mary Ward|Female||Active|||
    |Mr|Robert Webb|||Active|||

**CASE 2:** The above file could have a header and a footer. 
In which case, each row has an identifier called as Line head to determine the type of row in the file. 

    |H|Department|Jun 23 2016  7:01PM|
    |D||Jack Marias|Male|London|Active|||
    |D|Dr|Bony Stringer|Male|New Jersey|Active||Paid|
    |D|Mrs|Mary Ward|Female||Active|||
    |D|Mr|Robert Webb|||Active|||
    |F|4 Records|

**FileUtil** can be used to parse both the shown formats above. The line heads and data column delimiters (separators) are configurable as per required use case.

-------------


Using FileUtil
-------------


**Case 1:** Let us see how we can parse a delimiter separted file with no header and footer rows.
------------------------------------------------------------------------

 
**Note:** This file has rows with no line head as all lines are of same type
*ie. default is type of data.*  

> For the example rows below, we can parse the file with just few lines of code and minimal configuration.
> 
    |Mr|Jack Marias|Male|London|
    |Dr|Bony Stringer|Male|New Jersey|
    |Mrs|Mary Ward|Female||
    |Mr|Robert Webb|||
> 

**Configuration**
-------------

Add the following config to your application configuration file to let FileUtil know the location of the file to be read from. By default, the file is read from the file system using a default file provider. You can pass in your own implementation of the provider to custom read file from desired location. We will later show how you can acheive this.

> For now, At a minimal let the default provider know the file location
> and add no other attributes. You can override the defaults shown below
> (if needed)
> 

Below shows complete config required to parse a delimiter separated
file with no header and footer rows (or rows with no line heads).

    <configuration>     
	     <configSections>
	     <sectionGroup name="FileUtil">
	       <section name="Settings" type="Ninja.FileUtil.Configuration.Settings, Ninja.FileUtil" />
	    </sectionGroup>
	    </configSections>                    
     <FileUtil>
      <Settings>
        <Parser  delimiter="|"/>
        <Provider folderPath="C:work"
                  fileNameFormat="File*.txt" archiveUponRead="true" archiveFolder="Archived"/>    
      </Settings>
     </FileUtil>     
    </configuration>


 At a minimal, you can just specify the provider element with folder
 location and not specify any other attributes (default values shown
 will be used). `<provider folderPath="C:work"/>` 
 
 The fileNameFormat attribute shown (by default is empty) can
 be used to search the folder location for files with a specific name pattern.
 if not specified then all available files in the folder location will be searched.
 
 `<Provider                  fileNameFormat="File*.txt"/>`

**Code** 
-------------

You need to implement **FileLine** abstract class to craete a strongly typed line representation of the row in the delimiter separated file.

For the file below let us create the Line class.
> 
    |Mr|Jack Marias|Male|London|
    |Dr|Bony Stringer|Male|New Jersey|
    |Mrs|Mary Ward|Female||
    |Mr|Robert Webb|||
> 

 The line class implements FileLine and matches to the column index 
 using the column attribute and the data type of the data fields in the file row. You can also specify a default value in the column attribute should the data column be empty in the row.
 

     public class SingleLine : FileLine
        {
            [Column(0)]
            public string Title { get; set; }
            [Column(1)]
            public string Name { get; set; }
            [Column(2)]
            public string Sex { get; set; }
            [Column(3, "London")]
            public string Location { get; set; }
        } 

Then use the engine class to get the parsed values.

>
    var files = new Engine<SingleLine>(new Settings()).GetFiles();

The engine as shown in the code line above will parse the files found at the folder location specified in the config and return a collection of 
 `File<SingleLine>` objects, each with parsed strongly typed file line object arrays.


-------------


**Case 2:** Let us see how we can parse a delimiter separted file with header and footer rows.
------------------------------------------------------------------------


coming shortly ..


-------------


**Extending Functionality:** Let us see how we can implement custom file provider to use for custom file read requiremnts.
------------------------------------------------------------------------

coming shortly ..
