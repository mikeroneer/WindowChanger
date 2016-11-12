using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Ball_WindowChanger_WF
{
    public class AudioMixerHelper
    {

    public const int MMSYSERR_NOERROR = 0;
    public const int MAXPNAMELEN = 32;
    public const int MIXER_LONG_NAME_CHARS = 64;
    public const int MIXER_SHORT_NAME_CHARS = 16;
    public const int MIXER_GETLINEINFOF_COMPONENTTYPE = 0x3;
    public const int MIXER_GETCONTROLDETAILSF_VALUE = 0x0;
    public const int MIXER_GETLINECONTROLSF_ONEBYTYPE = 0x2;
    public const int MIXER_SETCONTROLDETAILSF_VALUE = 0x0;

    public const int MIXERLINE_COMPONENTTYPE_DST_FIRST = 0x0;
    public const int MIXERLINE_COMPONENTTYPE_SRC_FIRST = 0x1000;

    public const int MIXERLINE_COMPONENTTYPE_DST_SPEAKERS =
    (MIXERLINE_COMPONENTTYPE_DST_FIRST + 4);

    public const int MIXERLINE_COMPONENTTYPE_SRC_MICROPHONE =
    (MIXERLINE_COMPONENTTYPE_SRC_FIRST + 3);

    public const int MIXERLINE_COMPONENTTYPE_SRC_LINE =
    (MIXERLINE_COMPONENTTYPE_SRC_FIRST + 2);

    public const int MIXERCONTROL_CT_CLASS_FADER = 0x50000000;
    public const int MIXERCONTROL_CT_UNITS_UNSIGNED = 0x30000;

    public const int MIXERCONTROL_CONTROLTYPE_FADER =
    (MIXERCONTROL_CT_CLASS_FADER | MIXERCONTROL_CT_UNITS_UNSIGNED);

    public const int MIXERCONTROL_CONTROLTYPE_VOLUME =
    (MIXERCONTROL_CONTROLTYPE_FADER + 1);

    [ DllImport( "winmm.dll", CharSet=CharSet.Ansi )]
    private static extern int mixerClose (int hmx);
    [ DllImport( "winmm.dll", CharSet=CharSet.Ansi )]
    private static extern int mixerGetControlDetailsA (int hmxobj,ref
    MIXERCONTROLDETAILS pmxcd , int fdwDetails);
    [ DllImport( "winmm.dll", CharSet=CharSet.Ansi )]
    private static extern int mixerGetDevCapsA( int uMxId, MIXERCAPS
    pmxcaps, int cbmxcaps) ;
    [ DllImport( "winmm.dll", CharSet=CharSet.Ansi )]
    private static extern int mixerGetID (int hmxobj, int pumxID, int
    fdwId );
    [ DllImport( "winmm.dll", CharSet=CharSet.Ansi )]
    private static extern int mixerGetLineControlsA (int hmxobj,ref
    MIXERLINECONTROLS pmxlc, int fdwControls);
    [ DllImport( "winmm.dll", CharSet=CharSet.Ansi )]
    private static extern int mixerGetLineInfoA (int hmxobj,ref
    MIXERLINE pmxl , int fdwInfo);
    [ DllImport( "winmm.dll", CharSet=CharSet.Ansi )]
    private static extern int mixerGetNumDevs();
    [ DllImport( "winmm.dll", CharSet=CharSet.Ansi )]
    private static extern int mixerMessage(int hmx , int uMsg , int
    dwParam1 , int dwParam2);
    [ DllImport( "winmm.dll", CharSet=CharSet.Ansi )]
    private static extern int mixerOpen (out int phmx , int uMxId ,
    int dwCallback , int dwInstance , int fdwOpen);
    [ DllImport( "winmm.dll", CharSet=CharSet.Ansi )]
    private static extern int mixerSetControlDetails(int hmxobj ,ref
    MIXERCONTROLDETAILS pmxcd , int fdwDetails);

    public struct MIXERCAPS{
    public int wMid ; // manufacturer id
    public int wPid ; // product id
    public int vDriverVersion ; // version of the driver
    [ MarshalAs( UnmanagedType.ByValTStr, SizeConst=MAXPNAMELEN)]
    public string szPname ; // product name
    public int fdwSupport ; // misc. support bits
    public int cDestinations ; // count of destinations
    }

    public struct MIXERCONTROL{
    public int cbStruct ; // size in Byte of MIXERCONTROL
    public int dwControlID ; // unique control id for mixerdevice
    public int dwControlType ; // MIXERCONTROL_CONTROLpublicenum _xxx
    public int fdwControl ; // MIXERCONTROL_CONTROLF_xxx
    public int cMultipleItems ; // ifMIXERCONTROL_CONTROLF_MULTIPLE
    [ MarshalAs( UnmanagedType.ByValTStr,
    SizeConst=MIXER_SHORT_NAME_CHARS )]
    public string szShortName ; // short name of
    [ MarshalAs( UnmanagedType.ByValTStr,
    SizeConst=MIXER_LONG_NAME_CHARS )]
    public string szName ; // long name of
    public int lMinimum ; // Minimum value
    public int lMaximum ; // Maximum value
    //	 [ MarshalAs( UnmanagedType.ByValArray, SizeConst=10 )]
    [ MarshalAs( UnmanagedType.U4, SizeConst=10 )]
    public int reserved; // replaced // reserved structure space
    }

    public struct MIXERCONTROLDETAILS{
    public int cbStruct ; // size in Byte of MIXERCONTROLDETAILS
    public int dwControlID ; // control id to get/set details on
    public int cChannels ; // number of channels in paDetails array
    public int item ; // hwndOwner or cMultipleItems
    public int cbDetails ; // size of _one_ details_XX struct
    public IntPtr paDetails ; // pointer to array of details_XX structs
    }

    public struct MIXERCONTROLDETAILS_UNSIGNED{
    public int dwValue ; // value of the control
    }

    public struct MIXERLINE{
    public int cbStruct ; // size of MIXERLINE structure
    public int dwDestination ; // zero based destination index
    public int dwSource ; // zero based source index (if
    // source)
    public int dwLineID ; // unique line id for mixer device
    public int fdwLine ; // state/information about line
    public int dwUser ; // driver specific information
    public int dwComponentType ; // component public enum line connects to
    public int cChannels ; // number of channels line supports
    public int cConnections ; // number of connections (possible)
    public int cControls ;
    [ MarshalAs( UnmanagedType.ByValTStr,
    SizeConst=MIXER_SHORT_NAME_CHARS )] // number of controls at this line
    public string szShortName;
    [ MarshalAs( UnmanagedType.ByValTStr,
    SizeConst=MIXER_LONG_NAME_CHARS )]
    public string szName;
    public int dwType ;
    public int dwDeviceID ;
    public int wMid ;
    public int wPid ;
    public int vDriverVersion ;
    [ MarshalAs( UnmanagedType.ByValTStr, SizeConst=MAXPNAMELEN)]
    public string szPname ;
    }

    public struct MIXERLINECONTROLS{
    public int cbStruct ; // size in Byte of MIXERLINECONTROLS
    public int dwLineID ; // line id (from MIXERLINE.dwLineID)
    // MIXER_GETLINECONTROLSF_ONEBYID or
    public int dwControl ; // MIXER_GETLINECONTROLSF_ONEBYpublicenum
    public int cControls ; // count of controls pmxctrl points to
    public int cbmxctrl ; // size in Byte of _one_ MIXERCONTROL
    public IntPtr pamxctrl ; // pointer to first MIXERCONTROL array
    }

    private static bool GetVolumeControl(int hmixer ,int componentType,
    int ctrlType, out MIXERCONTROL mxc, out int vCurrentVol)
    {

    // This function attempts to obtain a mixer control.
    // Returns True if successful.
    MIXERLINECONTROLS mxlc = new MIXERLINECONTROLS();
    MIXERLINE mxl = new MIXERLINE();
    MIXERCONTROLDETAILS pmxcd = new MIXERCONTROLDETAILS();
    MIXERCONTROLDETAILS_UNSIGNED du = new
    MIXERCONTROLDETAILS_UNSIGNED();
    mxc = new MIXERCONTROL();
    int rc ;
    bool retValue;
    vCurrentVol = -1;

    //mxl.szShortName = new string(' ', MIXER_SHORT_NAME_CHARS);
    //mxl.szName = new string(' ', MIXER_LONG_NAME_CHARS);
    mxl.cbStruct = Marshal.SizeOf(mxl);
    mxl.dwComponentType = componentType ;

    // Obtain a line corresponding to the component public enum
    rc = mixerGetLineInfoA(hmixer,ref mxl,
    MIXER_GETLINEINFOF_COMPONENTTYPE );

    if(MMSYSERR_NOERROR == rc)
    {
    int sizeofMIXERCONTROL = 152;
    //Marshal.SizeOf(typeof(MIXERCONTROL))
    int ctrl = Marshal.SizeOf(typeof(MIXERCONTROL));
    mxlc.pamxctrl = Marshal.AllocCoTaskMem(sizeofMIXERCONTROL) ;//new MIXERCONTROL();
    mxlc.cbStruct = Marshal.SizeOf(mxlc);
    mxlc.dwLineID = mxl.dwLineID;
    mxlc.dwControl = ctrlType;
    mxlc.cControls = 1;
    mxlc.cbmxctrl = sizeofMIXERCONTROL;

    // Allocate a buffer for the control
    mxc.cbStruct = sizeofMIXERCONTROL;

    // Get the control
    rc = mixerGetLineControlsA(hmixer,ref mxlc,
    MIXER_GETLINECONTROLSF_ONEBYTYPE);

    if(MMSYSERR_NOERROR == rc)
    {
    retValue = true;

    // Copy the control into the destination structure
    mxc = (MIXERCONTROL)Marshal.PtrToStructure(mxlc.pamxctrl ,typeof(MIXERCONTROL));

    }
    else
    {
    retValue = false;
    }
    int sizeofMIXERCONTROLDETAILS =
    Marshal.SizeOf(typeof(MIXERCONTROLDETAILS));
    int sizeofMIXERCONTROLDETAILS_UNSIGNED =
    Marshal.SizeOf(typeof(MIXERCONTROLDETAILS_UNSIGNED ));
    pmxcd.cbStruct = sizeofMIXERCONTROLDETAILS;
    pmxcd.dwControlID = mxc.dwControlID;
    pmxcd.paDetails =
    Marshal.AllocCoTaskMem(sizeofMIXERCONTROLDETAILS_UNSIGNED) ;
    pmxcd.cChannels = 1;
    pmxcd.item = 0;
    pmxcd.cbDetails = sizeofMIXERCONTROLDETAILS_UNSIGNED;

    rc = mixerGetControlDetailsA(hmixer,ref pmxcd,
    MIXER_GETCONTROLDETAILSF_VALUE);

    du = (MIXERCONTROLDETAILS_UNSIGNED)Marshal.PtrToStructure(pmxcd.paDetails,typeof(MIXERCONTROLDETAILS_UNSIGNED));

    vCurrentVol = du.dwValue;

    return retValue;
    }

    retValue = false;
    return retValue;
    }

    private static bool SetVolumeControl(int hmixer , MIXERCONTROL mxc ,
    int volume )
    {
    // This function sets the value for a volume control.
    // Returns True if successful

    bool retValue;
    int rc;
    MIXERCONTROLDETAILS mxcd = new MIXERCONTROLDETAILS();
    MIXERCONTROLDETAILS_UNSIGNED vol = new
    MIXERCONTROLDETAILS_UNSIGNED();

    mxcd.item = 0;
    mxcd.dwControlID = mxc.dwControlID;
    mxcd.cbStruct = Marshal.SizeOf(mxcd);
    mxcd.cbDetails = Marshal.SizeOf(vol);

    // Allocate a buffer for the control value buffer
    mxcd.cChannels = 1;
    vol.dwValue = volume;

    // Copy the data into the control value buffer
    //mxcd.paDetails =vol;//(MIXERCONTROL)Marshal.PtrToStructure(mxlc.pamxctrl ,typeof(MIXERCONTROL));
    mxcd.paDetails = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(MIXERCONTROLDETAILS_UNSIGNED)));
    Marshal.StructureToPtr(vol, mxcd.paDetails,false);


    // Set the control value
    rc = mixerSetControlDetails(hmixer,ref mxcd,
    MIXER_SETCONTROLDETAILSF_VALUE);

    if(MMSYSERR_NOERROR == rc)
    {
    retValue = true;
    }
    else
    {
    retValue = false;
    }
    return retValue;
    }

    public static int GetVolume()
    {
    int mixer;
    MIXERCONTROL volCtrl = new MIXERCONTROL();
    int currentVol;
    mixerOpen(out mixer,0 ,0 ,0, 0);
    int type = MIXERCONTROL_CONTROLTYPE_VOLUME;
    GetVolumeControl(mixer,
    MIXERLINE_COMPONENTTYPE_DST_SPEAKERS,type,out volCtrl, out
    currentVol);
    mixerClose(mixer);

    return currentVol;


    }
    public static void SetVolume(int vVolume)
    {
    int mixer;
    MIXERCONTROL volCtrl = new MIXERCONTROL();
    int currentVol;
    mixerOpen(out mixer,0 ,0 ,0, 0);
    int type = MIXERCONTROL_CONTROLTYPE_VOLUME;
    GetVolumeControl(mixer,
    MIXERLINE_COMPONENTTYPE_DST_SPEAKERS,type,out volCtrl, out
    currentVol);
    if(vVolume>volCtrl.lMaximum) vVolume = volCtrl.lMaximum;
    if(vVolume<volCtrl.lMinimum) vVolume = volCtrl.lMinimum;
    SetVolumeControl(mixer, volCtrl, vVolume);
    GetVolumeControl(mixer,
    MIXERLINE_COMPONENTTYPE_DST_SPEAKERS,type,out volCtrl, out
    currentVol);
    if(vVolume!=currentVol)
    {
    throw new Exception("Cannot Set Volume");
    }
    mixerClose(mixer);
    }

}
}
