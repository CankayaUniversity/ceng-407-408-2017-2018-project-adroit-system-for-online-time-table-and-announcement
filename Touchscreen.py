import tkinter as tk                # python 3
from tkinter import font  as tkfont # python 3
#import Tkinter as tk     # python 2
#import tkFont as tkfont  # python 2
from tkinter import simpledialog
from tkinter import messagebox
LARGE_FONT = ("Times New Roman", 20)


class SampleApp(tk.Tk):    
    def __init__(self, *args, **kwargs):
        tk.Tk.__init__(self, *args, **kwargs)
        self.geometry("800x600") # set size of the main window to 800x600 pixels
        self.title_font = tkfont.Font(family='Helvetica', size=18, weight="bold", slant="italic")
        self.resizable(width=False, height=False)
        # the container is where we'll stack a bunch of frames
        # on top of each other, then the one we want visible
        # will be raised above the others
        container = tk.Frame(self)
        container.pack(side="top", fill="both", expand=True)
        container.grid_rowconfigure(0, weight=1)
        container.grid_columnconfigure(0, weight=1)

        self.frames = {}
        for F in (StartPage, PageOne, PageTwo):
            page_name = F.__name__
            frame = F(parent=container, controller=self)
            self.frames[page_name] = frame

            # put all of the pages in the same location;
            # the one on the top of the stacking order
            # will be the one that is visible.
            frame.grid(row=0, column=0, sticky="nsew")

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
        label.pack(pady=10, padx=10) # center alignment
        photo=tk.PhotoImage(file="left.png")
        photo2=tk.PhotoImage(file="right.png")


        leftbutton = tk.Button(self, image=photo,  # when click on this button, call the show_frame method to make PageOne appear
                            command=lambda : controller.show_frame("PageTwo"))
        leftbutton.image = photo

        leftbutton.place(x=0, y=250)
        
        rightbutton = tk.Button(self, image=photo2,  # when click on this button, call the show_frame method to make PageOne appear
                            command=lambda : controller.show_frame("PageOne"))
        rightbutton.image = photo2

        rightbutton.place(x=770, y=250)
        hourlabel1 = tk.Label(self, bg="white", text="09.20", height=5, width=8)
        hourlabel1.place(x=30, y=80)
        hourlabel2 = tk.Label(self, bg="white", text="10.20", height=5, width=8)
        hourlabel2.place(x=30, y=140)
        hourlabel3 = tk.Label(self, bg="white", text="11.20", height=5, width=8)
        hourlabel3.place(x=30, y=200)
        hourlabel4 = tk.Label(self, bg="white", text="12.20", height=5, width=8)
        hourlabel4.place(x=30, y=260)
        hourlabel5 = tk.Label(self, bg="white", text="13.20", height=5, width=8)
        hourlabel5.place(x=30, y=320)
        hourlabel6 = tk.Label(self, bg="white", text="14.20", height=5, width=8)
        hourlabel6.place(x=30, y=380)
        hourlabel7 = tk.Label(self, bg="white", text="15.20", height=5, width=8)
        hourlabel7.place(x=30, y=440)
        hourlabel8 = tk.Label(self, bg="white", text="16.20", height=5, width=8)
        hourlabel8.place(x=30, y=500)
        daylabel1 = tk.Label(self, bg="white", text="Monday", height=2, width=16)
        daylabel1.place(x=97, y=47)
        daylabel2 = tk.Label(self, bg="white", text="Tuesday", height=2, width=16)
        daylabel2.place(x=225, y=47)
        daylabel3 = tk.Label(self, bg="white", text="Wednesday", height=2, width=16)
        daylabel3.place(x=353, y=47)
        daylabel4 = tk.Label(self, bg="white", text="Thursday", height=2, width=16)
        daylabel4.place(x=481, y=47)
        daylabel5 = tk.Label(self, bg="white", text="Friday", height=2, width=16)
        daylabel5.place(x=609, y=47)
        
       

class PageOne(tk.Frame):
    
    def __init__(self, parent, controller):
        tk.Frame.__init__(self, parent, bg="yellow")
        self.controller = controller
        photo=tk.PhotoImage(file="left.png")
        photo2=tk.PhotoImage(file="right.png")
        label = tk.Label(self, text='Asst. Prof. Dr. Abdül Kadir GÖRÜR', font=LARGE_FONT, bg="yellow")
        label.pack(pady=10, padx=10) # center alignment
        self.e = tk.Entry(self,font=("Times New Roman", 14),width=11, borderwidth=2, relief= "sunken", justify="center")
               
        self.e.place(x=286, y=60)

        
        def err():
            messagebox.showwarning("Wrong E-Mail","Please Enter a Valid E-Mail!")
    
        def abc():
            email=self.e.get()
            email='c'+email+'@student.cankaya.edu.tr'
            print("Email: %s" % (email))
            if (email!='c1411031@student.cankaya.edu.tr'):
                err()
        
            
        b1 = tk.Button(self,font=("Times New Roman", 14),width=50,borderwidth=2, relief= "flat", text='------111111-----', command=abc, height=2)
        b1.place (x=150, y=130)
        b2 = tk.Button(self,font=("Times New Roman", 14),width=50,borderwidth=2, relief= "flat", text='------222222-----', command=abc , height=2)
        b2.place (x=150, y=210)
        b3 = tk.Button(self,font=("Times New Roman", 14),width=50,borderwidth=2, relief= "flat", text='------333333-----', command=abc , height=2)
        b3.place (x=150, y=290)
        b4 = tk.Button(self,font=("Times New Roman", 14),width=50,borderwidth=2, relief= "flat", text='------444444-----', command=abc , height=2)
        b4.place (x=150, y=370)        
        b5 = tk.Button(self,font=("Times New Roman", 14),width=50,borderwidth=2, relief= "flat", text='------555555-----', command=abc , height=2)
        b5.place (x=150, y=450)
        
        l1 = tk.Label(self, text="Enter E-Mail: c", borderwidth=2, relief= "flat", font=("Times New Roman", 15), width=13, height=2)
        l1.place (x=150, y=50)
        #self.textEntryVar = StringVar()#ana sayfa akan duyuru#sleeping in raspb        
                    
        l2 = tk.Label(self, text="@student.cankaya.edu.tr",borderwidth=2, relief= "flat", font=("Times New Roman", 15), width=20, height=2)
        l2.place (x=400, y=50) 
        leftbutton2 = tk.Button(self, image=photo,  # when click on this button, call the show_frame method to make PageOne appear
                            command=lambda : controller.show_frame("StartPage"))
        leftbutton2.image = photo

        leftbutton2.place(x=0, y=250)
        
        rightbutton2 = tk.Button(self, image=photo2,  # when click on this button, call the show_frame method to make PageOne appear
                            command=lambda : controller.show_frame("PageTwo"))
        rightbutton2.image = photo2

        rightbutton2.place(x=770, y=250)
         




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

        leftbutton2.place(x=0, y=250)
        
        rightbutton2 = tk.Button(self, image=photo2,  # when click on this button, call the show_frame method to make PageOne appear
                            command=lambda : controller.show_frame("StartPage"))
        rightbutton2.image = photo2

        rightbutton2.place(x=770, y=250)
       
    
    

if __name__ == "__main__":
    app = SampleApp()
    app.mainloop()
