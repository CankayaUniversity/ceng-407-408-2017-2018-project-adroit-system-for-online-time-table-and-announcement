# **Adroit System for Online Time Table and Announcement**
                                                                                                                                                                

* Timur ATİLA c1311006@student.cankaya.edu.tr

* Özlem KILIÇ c1311030@student.cankaya.edu.tr

* Hatice Nazlı KUŞ c1311037@student.cankaya.edu.tr

* Utku KILAVUZ c1411031@student.cankaya.edu.tr

	Advisor: Abdül Kadir GÖRÜR agorur@cankaya.edu.tr
  
# **Installation and Compilation Guide**

In this guide we describe how to install and compile the Adroit System for Online Time Table and Announcement project.

## **Prerequisites**

* Visual Studio 2015 or above should be installed to compile and run our website.
* Microsoft .NET Framework version 4.7.02556 or above should be installed.
* Android Studio version 3.1.2 or above should be installed to compile and run our mobile
application, older versions of Android Studio can cause undesired warnings or errors.
*For compiling our Python code use Idle for compilation. Make sure that the Python version
is 3.5.2 otherwise, there can be some errors in compilation stage.
* Our Python code uses some extra libraries. The list you should download your device;
	* Mysql connector for Python
	* Pi camera for Python
	* Image for Python
 
All of these libraries are required, if they are not installed then you get some compilation errors. 
  
**Important:** Make note that Python code will only work in Raspberry Pi 3. You can never use the Python code from other devices, otherwise you will get some compilation errors, that they are insoluble.

## **Compiling and Running**

### **Compiling and Running for Website**

* Copy the source files to master folder of projects of Visual Studio.
* Open Visual Studio → Open the project folders → Open website project file(Default name;
AdroitTimetableMysql) → Select ‘AdroitTimetableMysql.sln’ → Compile the Website
project.
   There are two way to running the Website;
* Running the project on Visual Studio
* Running the project on our Host from [here](https://www.cankayaweb.com). (This state is not required to compiling the
project)

### **Compiling and Running for Mobile Application**

* Copy the source files to master folder of projects of Android Studio.
* Open Android Studio → Open the project folders → Open mobile application file(Default
name; MobileAppCankaya) → Select the folder → Compile the Mobile Application
project.
* **Note:** Android Studio will ask to chance to dictionary for prepare project, please accept it,
so Android Studio project run from your device properly.
   There are two way to running the Mobile Application;
* Running the project from Android Studio
* Open MobileAppCankaya on Android Studio → ‘Ctrl+Shift+A’ search Edit Configurations
and select → Choose the project as Gradle project → In Tasks type assemble → Press OK.
Then the project .apk will be in the master folder of projects of Android Studio. Open
project folder → Open ‘app’ folder → Open ‘build’ folder → Open ‘outputs’ folder Copy
the ‘apk’ folder, open your phone dictionary → Open ‘Android’ folder → Open ‘data’
folder → Crate a folder named ‘com.webcankaya.mobileappcankaya’ → Paste the folder.
Open your phone install the .apk. Then run the Mobile Application.

**Important:** Make note that your phone version need to at least Android 4.4 KitKat to
running your program.

### **Compiling and Running for Python**
* Copy the source file of Python code and .png files in same dictionary. (Optional: You can
paste the source file to ‘/home’ dictionary , it will easy to find it.)
* Open Idle → Open source code → Compile the Source code.
   There are two ways to running the Python code;
* Running the project from Idle
* Copy the our executable folder named ‘Touchscreen’ in any dictionary. (Optional: You can
paste the source file to ‘/home’ dictionary , it will easy to find it.) → Open terminal → Type
‘cd Touchscreen && ./Touchscreen’. Our program will start automatically.
## **System Requirements**
There is no specific system requirements to compile or run our project.
### **Installation**
Download our project from [here](https://github.com/CankayaUniversity/ceng-407-408-project-adroit-system-for-online-time-table-and-announcement/releases).

**Note:** If there is any compilation or run time error, please contact with us.
## **Please refer to [User Manual](https://github.com/CankayaUniversity/ceng-407-408-project-adroit-system-for-online-time-table-and-announcement/wiki/User-Manual) before using the application to proper use.**
