﻿using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System;
using VRage.Collections;
using VRage.Game.Components;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game;
using VRageMath;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
        string OurName = "Wico Craft";
        string moduleName = "AntReceive";
        string sVersion = "3.0E";

        const string sGPSCenter = "Craft Remote Control";

        Vector3I iForward = new Vector3I(0, 0, 0);
        Vector3I iUp = new Vector3I(0, 0, 0);
        Vector3I iLeft = new Vector3I(0, 0, 0);
//        Vector3D currentPosition;
        const string velocityFormat = "0.00";

//        IMyTerminalBlock anchorPosition;
        IMyTerminalBlock gpsCenter = null;
//        Vector3D vCurrentPos;
        //IMyTerminalBlock gpsCenter = null;
        class OurException : Exception
        {
            public OurException(string msg) : base("WicoExampleModule" + ": " + msg) { }
        }

        string sLastMessage = "";

        void moduleDoPreModes()
        {
	        if (sReceivedMessage != "")
	        {
		        Echo("Processing Message:\n" + sReceivedMessage);

		        if (sLastMessage == sReceivedMessage)
		        {
			        Echo("Clearing last message: Not processed");
			        sReceivedMessage = ""; // clear it.
		        }

		        sLastMessage = sReceivedMessage;
	        }
	        else sLastMessage = "";
        }

        void modulePostProcessing()
        {
	        Echo(lPendingIncomingMessages.Count + " Pending Incoming Messages");
	        for (int i = 0; i < lPendingIncomingMessages.Count; i++)
		        Echo(i + ":" + lPendingIncomingMessages[i]);

            Echo(sInitResults);
            echoInstructions();
        }

        void ResetMotion(bool bNoDrills = false)  
        { 
        //	if (navEnable != null)	blockApplyAction(navEnable,"OnOff_Off"); //navEnable.ApplyAction("OnOff_Off"); 
//	        powerDownThrusters(thrustAllList);
//            gyrosOff();
	        blockApplyAction(gpsCenter, "AutoPilot_Off"); 
        } 

    }
}