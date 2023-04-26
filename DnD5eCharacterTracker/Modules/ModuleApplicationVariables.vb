Module ModuleApplicationVariables

#Disable Warning BC42300 ' XML comment block must immediately precede the language element to which it applies
#Disable Warning BC42312 ' XML documentation comments must precede member or type declarations

#Region " Constants "

    ''' <summary>
    ''' [ Program Branding. ]
    ''' </summary>
    Public Const COMPANYNAME As System.String = "Michael Rainey"
    Public Const COMPANYNAMESHORT As System.String = "Michael Rainey"
    Public Const PROGRAMNAME As System.String = "Dungeons & Dragons 5th Edition Character Tracker for Dungeon Masters"
    Public Const PROGRAMNAMESHORT As System.String = "DnD5eCharacterTracker"

    '[ Can either construct PROGRAMBUILD here -OR- contruct using SetProgramBuild function in ModuleApplication > Miscellaneous region. ]
    '[ If function is used, other PROGRAMBUILD constants below must be filled in. Function returns build string or 0.0.0 as default. ]
    Public Const PROGRAMBUILD As System.String = "1.0.0"
    '[ The following CONST are for Sematic Versioning. See https://en.wikipedia.org/wiki/Software_versioning for info. ]
    Public Const PROGRAMBUILDMAJORVERSION As System.String = "1" '[ New version or software-breaking changes. ]
    Public Const PROGRAMBUILDMINORVERSION As System.String = "0" '[ New non-breaking features or changes. ]
    Public Const PROGRAMBUILDPATCHVERSION As System.String = "0" '[ Other non-breaking features or changes. ]
    '[ PROGRAMBUILDRELEASETAG is used for items like 'a' (alpha), 'alpha', 'b' (beta), 'beta', or 'rc' (release candidate). ]
    Public Const PROGRAMBUILDPRERELEASETAG As System.String = ""
    '[ PROGRAMBUILDPRERELEASEVERSION is ONLY used to but a build number on an alpha, beta, or release candidate. ]
    Public Const PROGRAMBUILDPRERELEASEVERSION As System.String = ""

    '[ Year program created. ]
    Public Const COPYRIGHTYEAR As System.String = "2023"

    ''' <summary>
    ''' To be able to write to Windows Application Event Log in Event Viewer.
    ''' </summary>
    ''' <remarks>
    ''' REMINDER: See Code Snippets at the bottom of ModuleApplication for code on how to write events to the Event Viewer.
    ''' </remarks>
    Public Const PROGRAMEVENTLOG As System.String = "Application"


    '[ Technically constants. ]
    ''' <summary>
    ''' Paths to user's AppData folder, Windows Common AppData folder, program's Data subfolder, and program's Resources subfolder.
    ''' </summary>
    Public USERBASEDATAPATH As String = String.Format("{0}\{1}\{2}", GetFolderPath(SpecialFolder.ApplicationData), COMPANYNAMESHORT, PROGRAMNAMESHORT)
    Public APPBASEDATAPATH As String = String.Format("{0}\{1}\{2}", GetFolderPath(SpecialFolder.CommonApplicationData), COMPANYNAMESHORT, PROGRAMNAMESHORT)
    Public APPDEFAULTDATAPATH As String = String.Format("{0}\Data", Application.StartupPath)
    Public APPDEFAULTRESOURCEPATH As String = String.Format("{0}\Resources", Application.StartupPath)

    ''' <summary>
    ''' Paths in registry where program settings and data may be stored.
    ''' </summary>
    ''' <remarks>
    ''' REMINDER: In order to add/edit/delete HKEY_LOCAL_MACHINE rgistry keys, the program must have Administrator privileges.or be run as Administrator.
    '''           See Code Snippets at the bottom of ModuleApplication for code on how to set program to run as Administrator.
    ''' </remarks>
    Public REGISTRYKEYCURRENTUSER As System.String = System.String.Format("SOFTWARE\{0}\{1}", COMPANYNAMESHORT, PROGRAMNAMESHORT)
    Public REGISTRYKEYLOCALMACHINE As System.String = System.String.Format("SOFTWARE\{0}\{1}", COMPANYNAMESHORT, PROGRAMNAMESHORT)

#End Region

#Region " Variables "

    '[ Boolean Values. ]
    ''' <summary>
    ''' If software requires license for some/all functionality.
    ''' </summary>
    Public _IsLicensed As System.Boolean = False

    ''' <summary>
    ''' To determine if computer has a network connection.
    ''' </summary>
    ''' <remarks>
    ''' Used by NetworkAvailable procedure in ModuleApplication - Networking.
    ''' </remarks>
    Public _IsNetworkAvailable As System.Boolean = False


    '[ Integer Values. ]
    'Public _Campaign As Integer = 0



    '[ String Array Values. ]
    ''' <summary>
    ''' Allowed command-line arguments. If needed by program.
    ''' </summary>
    Public _CommandLineArguments() As System.String = {}


    '[ String Non-Array Values. ]



    '[ Collections ]
    ''' <summary>
    ''' Used for programs that need a Most Recent Used list of files.
    ''' </summary>
    'Public _MRUListTable As System.Collections.Hashtable = New System.Collections.Hashtable()
    Public _OpenDropShips As System.Collections.ArrayList = New System.Collections.ArrayList()
    Public _Campaign As System.Collections.Generic.Dictionary(Of String, String) = Nothing

    '[ Other Values. ]



    '[ ImageLists - Standard. ]
    ''' <summary>
    ''' Size of images to go in ImageList is indicated in name.
    ''' Use SubProcedure LoadImagesToImageList() in ModuleApplication to fill ImageLists.
    ''' </summary>
    'Public _ImageList16 As System.Windows.Forms.ImageList
    'Public _ImageList20 As System.Windows.Forms.ImageList
    'Public _ImageList24 As System.Windows.Forms.ImageList
    'Public _ImageList32 As System.Windows.Forms.ImageList
    'Public _ImageList40 As System.Windows.Forms.ImageList
    'Public _ImageList48 As System.Windows.Forms.ImageList
    'Public _ImageList64 As System.Windows.Forms.ImageList
    'Public _ImageList96 As System.Windows.Forms.ImageList
    'Public _ImageList128 As System.Windows.Forms.ImageList

    '[ ImageLists - Program Specific. ]
    ''' <summary>
    ''' Size of images to go in ImageList should be indicated in name. Ex: ImageList16 for 16x16 images.
    ''' </summary>


    '[ Color Brushes - Standard. ]
    ''' <summary>
    ''' Color Adjectives (from darkest to lightest): Deep, Gloom, Dark, Normal, Light, Faded, Faint. Black and White do not use Adjectives.
    ''' </summary>
    Public _BrushBlackColor As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0))
    Public _BrushGrayColorDeep As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(32, 32, 32))
    Public _BrushGrayColorGloom As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(64, 64, 64))
    Public _BrushGrayColorDark As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(96, 96, 96))
    Public _BrushGrayColor As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(128, 128, 128))
    Public _BrushGrayColorLight As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(160, 160, 160))
    Public _BrushGrayColorFaded As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(192, 192, 192))
    Public _BrushGrayColorFaint As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(224, 224, 224))
    Public _BrushWhiteColor As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 255, 255))

    '[ Color Brushes - Program Specific. ]
    ''' <summary>
    ''' Copy the codeblock and replace [[COLOR]] with the name of the color. Delete unused.
    ''' Color Adjectives (from darkest to lightest): Deep, Gloom, Dark, Normal, Light, Faded, Faint. Black and White do not use Adjectives.
    ''' 
    ''' Public Brush[[COLOR]]Color[[ColorAdj]] As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0))
    ''' </summary>
    Public _BrushBlueColorGloom As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 80, 137))
    Public _BrushBlueColorDark As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 92, 158))
    Public _BrushBlueColor As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(1, 115, 199))
    Public _BrushBlueColorLight As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(223, 240, 254))

    Public _BrushGreenColorGloom As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 80, 137))
    Public _BrushGreenColorDark As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 92, 158))
    Public _BrushGreenColor As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(1, 115, 199))
    Public _BrushGreenColorLight As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(223, 240, 254))

    Public _BrushRedColorGloom As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 80, 137))
    Public _BrushRedColorDark As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 92, 158))
    Public _BrushRedColor As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(1, 115, 199))
    Public _BrushRedColorLight As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(223, 240, 254))

    Public _BrushOrangeColorGloom As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 80, 137))
    Public _BrushOrangeColorDark As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 92, 158))
    Public _BrushOrangeColor As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(1, 115, 199))
    Public _BrushOrangeColorLight As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(223, 240, 254))

    Public _BrushPurpleColorGloom As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 80, 137))
    Public _BrushPurpleColorDark As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 92, 158))
    Public _BrushPurpleColor As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(1, 115, 199))
    Public _BrushPurpleColorLight As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(223, 240, 254))

    '[ Color Pens - Standard. ]
    ''' <summary>
    ''' Color Adjectives (from darkest to lightest): Deep, Gloom, Dark, Normal, Light, Faded, Faint. Black and White do not use Adjectives.
    ''' Thickness Adjectives (from thickest to thinnest, with typical widths): Huge [9-10], Large [7-8], Medium [5-6], Fine [3-4], Ultrafine [1-2].
    ''' Use "With ... End With" to set properties of the pen.
    ''' Pens thicker than 10 should be drawn using .FillRectangle instead.
    ''' </summary>
    Public _PenBlackColor As New System.Drawing.Pen(System.Drawing.Color.FromArgb(0, 0, 0))
    Public _PenGrayColorDeep As New System.Drawing.Pen(System.Drawing.Color.FromArgb(32, 32, 32))
    Public _PenGrayColorGloom As New System.Drawing.Pen(System.Drawing.Color.FromArgb(64, 64, 64))
    Public _PenGrayColorDark As New System.Drawing.Pen(System.Drawing.Color.FromArgb(96, 96, 96))
    Public _PenGrayColor As New System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 128, 128))
    Public _PenGrayColorLight As New System.Drawing.Pen(System.Drawing.Color.FromArgb(160, 160, 160))
    Public _PenGrayColorFaded As New System.Drawing.Pen(System.Drawing.Color.FromArgb(192, 192, 192))
    Public _PenGrayColorFaint As New System.Drawing.Pen(System.Drawing.Color.FromArgb(224, 224, 224))
    Public _PenWhiteColor As New System.Drawing.Pen(System.Drawing.Color.FromArgb(255, 255, 255))

    '[ Color Pens - Program Specific. ]
    ''' <summary>
    ''' Copy the codeblock and replace [[COLOR]] with the name of the color. Delete unused.
    ''' Color Adjectives (from darkest to lightest): Deep, Gloom, Dark, Normal, Light, Faded, Faint. Black and White do not use Adjectives.
    ''' Thickness Adjectives (from thickest to thinnest, with typical widths): Huge [9-10], Large [7-8], Medium [5-6], Fine [3-4], Ultrafine [1-2].
    ''' 
    ''' Public Pen[[COLOR]]Color[[ColorAdj]][[ThicknessAdj]] As New System.Drawing.Pen(System.Drawing.Color.FromArgb(0, 0, 0))
    ''' 
    ''' Use "With ... End With" to set properties of the pen.
    ''' Pens thicker than 10 should be drawn using .DrawRectangle instead.
    ''' </summary>


#End Region

#Enable Warning BC42312 ' XML documentation comments must precede member or type declarations
#Enable Warning BC42300 ' XML comment block must immediately precede the language element to which it applies

End Module
