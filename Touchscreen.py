import mysql.connector
from datetime import datetime
import tkinter as tk  
from tkinter import font  as tkfont
from tkinter import simpledialog
from tkinter import messagebox
import time
#from time import sleep
import RPi.GPIO as GPIO
import os
import picamera
from PIL import Image

LARGE_FONT = ("Times New Roman", 20)

cnx = mysql.connector.connect(user='efe', password='efe123',
                              host='206.189.26.46', database='AdroitDatabase')

oldtime = time.time()

class SampleApp(tk.Tk):    
    def __init__(self, *args, **kwargs):
        tk.Tk.__init__(self, *args, **kwargs)
        
        self.geometry("800x480") # set size of the main window to 800x600 pixels
        self.title_font = tkfont.Font(family='Helvetica', size=18, weight="bold", slant="italic")
        self.resizable(width=False, height=False)
        self.attributes("-fullscreen", True)
       
        # the container is where we'll stack a bunch of frames
        # on top of each other, then the one we want visible
        # will be raised above the others
        container = tk.Frame(self)
        container.pack(side="top", fill="both", expand=True)
        container.grid_rowconfigure(0, weight=1)
        container.grid_columnconfigure(0, weight=1)

        self.frames = {}
        for F in (PageTwo, PageOne, StartPage):
            page_name = F.__name__
            frame = F(parent=container, controller=self)
            self.frames[page_name] = frame

            # put all of the pages in the same location;
            # the one on the top of the stacking order
            # will be the one that is visible.
            frame.grid(row=0, column=0, sticky="nsew")
        GPIO.setmode(GPIO.BCM)
        GPIO.setwarnings(False)
        GPIO.setup(21, GPIO.IN, pull_up_down=GPIO.PUD_DOWN)
        def motionSensor(channel):
            if GPIO.input(21):
                print('Motion Detected')
                os.system('xscreensaver-command -deactivate')
                os.system('xset s reset')
                global oldtime
                if time.time() - oldtime > 59:
                    oldtime = time.time()
                    self.show_frame("StartPage")
        GPIO.add_event_detect(21, GPIO.BOTH, callback=motionSensor, bouncetime=1)
        self.show_frame("StartPage")

    def show_frame(self, page_name):
        '''Show a frame for the given page name'''
        frame = self.frames[page_name]
        frame.tkraise()
        


class StartPage(tk.Frame):

    def __init__(self, parent, controller):
        tk.Frame.__init__(self, parent, bg="yellow", height=600, width=800)
        self.controller = controller
        label = tk.Label(self, text='Asst. Prof. Dr. Abdül Kadir GÖRÜR', font=LARGE_FONT, bg="yellow")
        label.pack(pady=10, padx=10)
        photo=tk.PhotoImage(file="left.png")
        photo2=tk.PhotoImage(file="right.png")


        leftbutton = tk.Button(self, image=photo,  # when click on this button, call the show_frame method to make PageOne appear
                            command=lambda : controller.show_frame("PageTwo"))
        leftbutton.image = photo

        leftbutton.place(x=0, y=200)
        
        rightbutton = tk.Button(self, image=photo2,  # when click on this button, call the show_frame method to make PageOne appear
                            command=lambda : controller.show_frame("PageOne"))
        rightbutton.image = photo2

        rightbutton.place(x=770, y=200)
        hourlabel1 = tk.Label(self, bg="white", text="09.20", height=3, width=5)
        hourlabel1.place(x=30, y=80)
        hourlabel2 = tk.Label(self, bg="white", text="10.20", height=3, width=5)
        hourlabel2.place(x=30, y=127)
        hourlabel3 = tk.Label(self, bg="white", text="11.20", height=3, width=5)
        hourlabel3.place(x=30, y=174)
        hourlabel4 = tk.Label(self, bg="white", text="12.20", height=3, width=5)
        hourlabel4.place(x=30, y=221)
        hourlabel5 = tk.Label(self, bg="white", text="13.20", height=3, width=5)
        hourlabel5.place(x=30, y=268)
        hourlabel6 = tk.Label(self, bg="white", text="14.20", height=3, width=5)
        hourlabel6.place(x=30, y=315)
        hourlabel7 = tk.Label(self, bg="white", text="15.20", height=3, width=5)
        hourlabel7.place(x=30, y=362)
        hourlabel8 = tk.Label(self, bg="white", text="16.20", height=3, width=5)
        hourlabel8.place(x=30, y=409)
        daylabel1 = tk.Label(self, bg="white", text="Monday", height=2, width=17)
        daylabel1.place(x=73, y=47)
        daylabel2 = tk.Label(self, bg="white", text="Tuesday", height=2, width=17)
        daylabel2.place(x=213, y=47)
        daylabel3 = tk.Label(self, bg="white", text="Wednesday", height=2, width=17)
        daylabel3.place(x=353, y=47)
        daylabel4 = tk.Label(self, bg="white", text="Thursday", height=2, width=17)
        daylabel4.place(x=493, y=47)
        daylabel5 = tk.Label(self, bg="white", text="Friday", height=2, width=17)
        daylabel5.place(x=633, y=47)
        
        cur = cnx.cursor()
        cur.execute('SELECT * FROM Lectures WHERE TeacherID = 1')
        data = cur.fetchall()
               
        cnx.commit()
        for row in data:
            day = str(row[4])
            hour = str(row[5])
            if day == "Monday" and hour == "09:20" :
                row = list(row)
                if str(row[7]) == "None":
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=93)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=93)
                row = tuple(row)
                
            if day == "Monday" and hour == "10:20" :
                row = list(row)
                if str(row[7]) == "None":
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=140)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=140)
                row = tuple(row)
            if day == "Monday" and hour == "11:20" :
                row = list(row)
                if str(row[7]) == "None":
                    
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=187)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=187)
                row = tuple(row)
            if day == "Monday" and hour == "12:20" :
                row = list(row)
                if str(row[7]) == "None":
                   
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=234)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=234)
                row = tuple(row)
            if day == "Monday" and hour == "13:20" : 
                row = list(row)
                if str(row[7]) == "None":
                   
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=281)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=281)
                row = tuple(row)
            if day == "Monday" and hour == "14:20" :
                row = list(row)
                if str(row[7]) == "None":
                    
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=328)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=328)
                row = tuple(row)
            if day == "Monday" and hour == "15:20" :
                row = list(row)
                if str(row[7]) == "None":
                   
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=375)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=375)
                row = tuple(row)
            if day == "Monday" and hour == "16:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=422)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=80, y=422)
                row = tuple(row)
            if day == "Tuesday" and hour == "09:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=222, y=93)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=230, y=93)
                row = tuple(row)
                
            if day == "Tuesday" and hour == "10:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=222, y=140)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=230, y=140)
                row = tuple(row)
            if day == "Tuesday" and hour == "11:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=222, y=187)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=230, y=187)
                row = tuple(row)
            if day == "Tuesday" and hour == "12:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=222, y=234)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=230, y=234)
                row = tuple(row)
            if day == "Tuesday" and hour == "13:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=222, y=281)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=230, y=281)
                row = tuple(row)
            if day == "Tuesday" and hour == "14:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=222, y=328)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=230, y=328)
                row = tuple(row)
            if day == "Tuesday" and hour == "15:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=222, y=375)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=230, y=375)
                row = tuple(row)
            if day == "Tuesday" and hour == "16:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=222, y=422)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=230, y=422)
                row = tuple(row)
            if day == "Wednesday" and hour == "09:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=364, y=93)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=372, y=93)
                row = tuple(row)
                
            if day == "Wednesday" and hour == "10:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=364, y=140)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=372, y=140)
                row = tuple(row)
            if day == "Wednesday" and hour == "11:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=364, y=187)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=372, y=187)
                row = tuple(row)
            if day == "Wednesday" and hour == "12:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=364, y=234)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=372, y=234)
                row = tuple(row)
            if day == "Wednesday" and hour == "13:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=364, y=281)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=372, y=281)
                row = tuple(row)
            if day == "Wednesday" and hour == "14:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=364, y=328)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=372, y=328)
                row = tuple(row)
            if day == "Wednesday" and hour == "15:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=364, y=375)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=372, y=375)
                row = tuple(row)
            if day == "Wednesday" and hour == "16:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=364, y=422)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=372, y=422)
                row = tuple(row)
            if day == "Thursday" and hour == "09:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=506, y=93)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=514, y=93)
                row = tuple(row)
                
            if day == "Thursday" and hour == "10:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=506, y=140)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=514, y=140)
                row = tuple(row)
            if day == "Thursday" and hour == "11:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=506, y=187)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=514, y=187)
                row = tuple(row)
            if day == "Thursday" and hour == "12:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=506, y=234)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=514, y=234)
                row = tuple(row)
            if day == "Thursday" and hour == "13:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=506, y=281)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=514, y=281)
                row = tuple(row)
            if day == "Thursday" and hour == "14:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=506, y=328)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=514, y=328)
                row = tuple(row)
            if day == "Thursday" and hour == "15:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=506, y=375)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=514, y=375)
                row = tuple(row)
            if day == "Thursday" and hour == "16:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=506, y=422)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=514, y=422)
                row = tuple(row)
            if day == "Friday" and hour == "09:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=648, y=93)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=656, y=93)
                row = tuple(row)
                
            if day == "Friday" and hour == "10:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=648, y=140)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=656, y=140)
                row = tuple(row)
            if day == "Friday" and hour == "11:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=648, y=187)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=656, y=187)
                row = tuple(row)
            if day == "Friday" and hour == "12:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=648, y=234)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=656, y=234)
                row = tuple(row)
            if day == "Friday" and hour == "13:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=648, y=281)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=656, y=281)
                row = tuple(row)
            if day == "Friday" and hour == "14:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=648, y=328)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=656, y=328)
                row = tuple(row)
            if day == "Friday" and hour == "15:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=648, y=375)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=656, y=375)
                row = tuple(row)
            if day == "Friday" and hour == "16:20" :
                row = list(row)
                if str(row[7]) == "None":         
                    row[6] = str(row[6]).replace("(", "")
                    row[6] = str(row[6]).replace(")", "")
                    row[6] = str(row[6]).replace(",", "")
                    row[6] = str(row[6]).replace("'", "")
                    sep = ' '
                    row[6] = str(row[6]).split(sep, 1)[0]
                    printScreen = tk.Label(self, text=str(row[2])+str(row[3])+" (" + str(row[6])+")", bg="yellow", font = (None, 11))
                    printScreen.place(x=648, y=422)
                else:
                    printScreen = tk.Label(self, text=str(row[7]), bg="yellow", font = (None, 11))
                    printScreen.place(x=656, y=422)
                row = tuple(row)
                

class PageOne(tk.Frame):   
    
    
    def __init__(self, parent, controller, master=None):
        tk.Frame.__init__(self, parent, bg="yellow")
        self.controller = controller
        self.textEntryVar = tk.StringVar()#ana sayfa akan duyuru#sleeping in raspb
        photo=tk.PhotoImage(file="left.png")
        photo2=tk.PhotoImage(file="right.png")
        label = tk.Label(self, text='Asst. Prof. Dr. Abdül Kadir GÖRÜR', font=LARGE_FONT, bg="yellow")
        label.grid(pady=10, padx=192) # center alignment
        self.e = tk.Entry(self,font=("Times New Roman", 14),width=10, borderwidth=2, relief= "sunken", justify="center")
        self.e.place(x=293, y=50, height=54)
        b1 = tk.Button(self,font=("Times New Roman", 15),width=45,borderwidth=2, relief= "flat", text='Can I get an appointment?', command=self.a, height=3)
        b1.place (x=25, y=120)
        b2 = tk.Button(self,font=("Times New Roman", 15),width=45,borderwidth=2, relief= "flat", text='When can I look at my exam paper?', command=self.b , height=3)
        b2.place (x=25, y=210)
        b3 = tk.Button(self,font=("Times New Roman", 15),width=45,borderwidth=2, relief= "flat", text='I came but I could not find you.', command=self.c , height=3)
        b3.place (x=25, y=300)
        b4 = tk.Button(self,font=("Times New Roman", 15),width=45,borderwidth=2, relief= "flat", text='May I get information about the Lab lesson?', command=self.d , height=3)
        b4.place (x=25, y=390)        
##        b5 = tk.Button(self,font=("Times New Roman", 15),width=45,borderwidth=2, relief= "flat", text='------555555-----', command=self.e , height=3)
##        b5.place (x=25, y=490)
        n7 = tk.Button(self, font=("Times New Roman", 18), text="7", command=lambda: self.set_text("7"))
        n7.place (x=510, y=130, width=85, height=85)        
        n8 = tk.Button(self, font=("Times New Roman", 18),text="8", command=lambda: self.set_text("8"))
        n8.place (x=595, y=130, width=85, height=85) 
        n9 = tk.Button(self, font=("Times New Roman", 18),text="9", command=lambda: self.set_text("9"))
        n9.place (x=680, y=130, width=85, height=85)        
        n4 = tk.Button(self, font=("Times New Roman", 18),text="4", command=lambda: self.set_text("4"))
        n4.place (x=510, y=215, width=85, height=85)
        n5 = tk.Button(self, font=("Times New Roman", 18),text="5", command=lambda: self.set_text("5"))
        n5.place (x=595, y=215, width=85, height=85)
        n6 = tk.Button(self, font=("Times New Roman", 18),text="6", command=lambda: self.set_text("6"))
        n6.place (x=680, y=215, width=85, height=85)
        n1 = tk.Button(self, font=("Times New Roman", 18),text="1", command=lambda: self.set_text("1"))
        n1.place (x=510, y=300, width=85, height=85)
        n2 = tk.Button(self, font=("Times New Roman", 18),text="2", command=lambda: self.set_text("2"))
        n2.place (x=595, y=300, width=85, height=85)
        n3 = tk.Button(self, font=("Times New Roman", 18),text="3", command=lambda: self.set_text("3"))
        n3.place (x=680, y=300, width=85, height=85)
        n0 = tk.Button(self, font=("Times New Roman", 18),text="0", command=lambda: self.set_text("0"))
        n0.place (x=595, y=385, width=85, height=85)
        de = tk.Button(self, font=("Times New Roman", 18),text="Del", command=lambda: self.set_text("del"))
        de.place (x=510, y=385, width=85, height=85)
        res = tk.Button(self, font=("Times New Roman", 18),text="Reset", command=lambda: self.set_text("res"))
        res.place (x=680, y=385, width=85, height=85)
        l1 = tk.Label(self, text="Enter E-Mail: c", borderwidth=2, relief= "flat", font=("Times New Roman", 16), width=13, height=2)
        l1.place (x=150, y=50)
        #self.textEntryVar = StringVar()#ana sayfa akan duyuru#sleeping in raspb        
                    
        l2 = tk.Label(self, text="@student.cankaya.edu.tr",borderwidth=2, relief= "flat", font=("Times New Roman", 16), width=20, height=2)
        l2.place (x=400, y=50) 
        leftbutton2 = tk.Button(self, image=photo,  # when click on this button, call the show_frame method to make PageOne appear
                            command=lambda : controller.show_frame("StartPage"))
        leftbutton2.image = photo

        leftbutton2.place(x=0, y=200)
        
        rightbutton2 = tk.Button(self, image=photo2,  # when click on this button, call the show_frame method to make PageOne appear
                            command=lambda : controller.show_frame("PageTwo"))
        rightbutton2.image = photo2

        rightbutton2.place(x=770, y=200)



    def numpadExit(self,event):
        counter=0
        self.edited = False
        self.e['bg']= '#ffffff'

    def err(self):
        messagebox.showwarning("Warning!","Please Enter a Valid E-Mail!")


    def warn(self):
        messagebox.showinfo("","Your Photo Will Be Taken In 5 Seconds. Please Press OK!")
        time.sleep(5)


    def a(self):
        
        email=self.e.get()
        if len(self.e.get()) == 7:        
            a = int(email[0])
            b = int(email[1])
            c = int(email[2])
            d = int(email[3])
            e = int(email[4])
            email='c'+email+'@student.cankaya.edu.tr'
            if  ((a != 1) | (a != 2)) & ((b < 0) | (b > 7)) & (c != 1) & (d != 1) & ((e < 0) | (e > 4)):
                self.err()
            email2=email+'.jpeg'
            self.warn()
            with picamera.PiCamera() as camera:
                camera.capture(email2)
            mes='Can I get an appointment?'
            name = "agorur@cankaya.edu.tr"
            str_now = datetime.now()
            blob_value = open('/home/pi/Desktop/Adroit/'+email2, 'rb').read()
            add_message = ("INSERT INTO Messages "
               "(MessageID, SenderName, TeacherID, MessageContent, TimeSent, ReceiverName, IsActive, PhotoUrl, Image) "
               "VALUES (DEFAULT, %s, %s, %s, %s, %s, %s, %s, %s)")
            data_message = (email, 1, mes, str_now, name, 1, email2, blob_value)
            cur = cnx.cursor()
            cur.execute(add_message, data_message)
            cnx.commit()
        elif len(self.e.get()) != 7:
            self.err()
        self.e.delete(0, 'end')

    def b(self):
        email=self.e.get()
        if len(self.e.get()) == 7:        
            a = int(email[0])
            b = int(email[1])
            c = int(email[2])
            d = int(email[3])
            e = int(email[4])
            email='c'+email+'@student.cankaya.edu.tr'
            if  ((a != 1) | (a != 2)) & ((b < 0) | (b > 7)) & (c != 1) & (d != 1) & ((e < 0) | (e > 4)):
                self.err()
            email2=email+'.jpeg'
            self.warn()
            with picamera.PiCamera() as camera:
                camera.capture(email2)
            mes='When can I look at my exam paper?'
            name = "Abdül Kadir GORUR"
            str_now = datetime.now()
            blob_value = open('/home/pi/Desktop/Adroit/'+email2, 'rb').read()
            add_message = ("INSERT INTO Messages "
               "(MessageID, SenderName, TeacherID, MessageContent, TimeSent, ReceiverName, IsActive, PhotoUrl, Image) "
               "VALUES (DEFAULT, %s, %s, %s, %s, %s, %s, %s, %s)")
            data_message = (email, 1, mes, str_now, name, 1, email2, blob_value)
            cur = cnx.cursor()
            cur.execute(add_message, data_message)
            cnx.commit()
        elif len(self.e.get()) != 7:
            self.err()
        self.e.delete(0, 'end')
        
    def c(self):
        email=self.e.get()
        if len(self.e.get()) == 7:        
            a = int(email[0])
            b = int(email[1])
            c = int(email[2])
            d = int(email[3])
            e = int(email[4])
            email='c'+email+'@student.cankaya.edu.tr'
            if  ((a != 1) | (a != 2)) & ((b < 0) | (b > 7)) & (c != 1) & (d != 1) & ((e < 0) | (e > 4)):
                self.err()
            email2=email+'.jpeg'
            self.warn()
            with picamera.PiCamera() as camera:
                camera.capture(email2)
            mes='I came but I could not find you'
            name = "Abdül Kadir GORUR"
            str_now = datetime.now()
            blob_value = open('/home/pi/Desktop/Adroit/'+email2, 'rb').read()
            add_message = ("INSERT INTO Messages "
               "(MessageID, SenderName, TeacherID, MessageContent, TimeSent, ReceiverName, IsActive, PhotoUrl, Image) "
               "VALUES (DEFAULT, %s, %s, %s, %s, %s, %s, %s, %s)")
            data_message = (email, 1, mes, str_now, name, 1, email2, blob_value)
            cur = cnx.cursor()
            cur.execute(add_message, data_message)
            cnx.commit()
            
        elif len(self.e.get()) != 7:
            self.err()
        self.e.delete(0, 'end')
        
    def d(self):
        email=self.e.get()
        if len(self.e.get()) == 7:        
            a = int(email[0])
            b = int(email[1])
            c = int(email[2])
            d = int(email[3])
            e = int(email[4])
            email='c'+email+'@student.cankaya.edu.tr'
            if  ((a != 1) | (a != 2)) & ((b < 0) | (b > 7)) & (c != 1) & (d != 1) & ((e < 0) | (e > 4)):
                self.err()
            email2=email+'.jpeg'
            self.warn()
            with picamera.PiCamera() as camera:
                camera.capture(email2)
            mes='May I get information about the Lab lesson?'
            name = "Abdül Kadir GORUR"
            str_now = datetime.now()
            blob_value = open('/home/pi/Desktop/Adroit/'+email2, 'rb').read()
            add_message = ("INSERT INTO Messages "
               "(MessageID, SenderName, TeacherID, MessageContent, TimeSent, ReceiverName, IsActive, PhotoUrl, Image) "
               "VALUES (DEFAULT, %s, %s, %s, %s, %s, %s, %s, %s)")
            data_message = (email, 1, mes, str_now, name, 1, email2, blob_value)
            cur = cnx.cursor()
            cur.execute(add_message, data_message)
            cnx.commit()
        elif len(self.e.get()) != 7:
            self.err()
        self.e.delete(0, 'end')

    def set_text(self, text):
        if text == "del":
            self.e.delete(len(self.e.get())-1)
        else:
            widget = self.focus_get()
            if widget in [self.e]:
                widget.insert("insert", text)

    
        
class PageTwo(tk.Frame):

     def __init__(self, parent, controller):
        tk.Frame.__init__(self, parent, bg="yellow")
        self.controller = controller
        photo=tk.PhotoImage(file="left.png")
        photo2=tk.PhotoImage(file="right.png")
        label = tk.Label(self, text='Asst. Prof. Dr. Abdül Kadir GÖRÜR', font=LARGE_FONT, bg="yellow")
        label.pack(pady=10, padx=10) # center alignment
 
        leftbutton2 = tk.Button(self, image=photo,  # when click on this button, call the show_frame method to make PageOne appear
                            command=lambda : controller.show_frame("PageOne"))
        leftbutton2.image = photo

        leftbutton2.place(x=0, y=200)
        
        rightbutton2 = tk.Button(self, image=photo2,  # when click on this button, call the show_frame method to make PageOne appear
                            command=lambda : controller.show_frame("StartPage"))
        rightbutton2.image = photo2

        rightbutton2.place(x=770, y=200)

        curtime = datetime.now()
        cur = cnx.cursor()
        cnx.commit()
        cur.execute('SELECT AnnContent, PublishDate, ExpDate FROM Teacher_Ann where IsActive=1 and TeacherID = 1')
        data = cur.fetchall()

        for row in data:
            if curtime < row[2] or curtime == row[2]:
                format_string = "%Y-%m-%d"
                rt= str(row[0])+ '  ' + datetime.strftime(datetime.date(row[1]),format_string) 
                printScreen = tk.Label(self, text=rt, bg="yellow", font = ("Times New Roman", 16))
                printScreen.pack(padx=5, pady=5)
##            
    
    

if __name__ == "__main__":
    app = SampleApp()
    app.mainloop()
