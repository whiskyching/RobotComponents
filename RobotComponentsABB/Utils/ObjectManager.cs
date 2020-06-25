﻿// This file is part of RobotComponents. RobotComponents is licensed 
// under the terms of GNU General Public License as published by the 
// Free Software Foundation. For more information and the LICENSE file, 
// see <https://github.com/EDEK-UniKassel/RobotComponents>.

// System Libs
using System;
using System.Linq;
using System.Collections.Generic;
// RobotComponents Libs
using RobotComponents.BaseClasses.Actions;
using RobotComponents.BaseClasses.Definitions;
using RobotComponentsABB.Components.Obsolete;
using RobotComponentsABB.Components.CodeGeneration;
using RobotComponentsABB.Components.Definitions;

namespace RobotComponentsABB.Utils
{
    /// <summary>
    /// The ObjectManager keeps track of different variables to enable global funcionalities
    /// </summary>

    public class ObjectManager
    {
        #region fields
        // contains information on all targets in file to notify user about duplicates
        private Dictionary<Guid, AbsoluteJointMovementComponent> _jointTargetsByGuid;
        private Dictionary<Guid, TargetComponent> _targetsByGuid;
        private List<string> _targetNames;

        // contains information on all speedDatas in file to notify the user about duplicates
        private Dictionary<Guid, SpeedDataComponent> _speedDatasByGuid;
        private List<string> _speedDataNames;

        // contains information on all zoneDatas in file to notify the user about duplicates
        private Dictionary<Guid, ZoneDataComponent> _zoneDatasByGuid;
        private List<string> _zoneDataNames;

        // constains information on all external axes in file to notify the user about duplicates
        private Dictionary<Guid, ExternalLinearAxisComponent> _externalLinearAxesByGuid;
        private Dictionary<Guid, ExternalRotationalAxisComponent> _externalRotationalAxesByGuid;
        private List<string> _axisNames;

        // contains information on all robot tools in file for code generation
        private Dictionary<Guid, RobotToolFromPlanesComponent> _toolsPlanesByGuid;
        private Dictionary<Guid, RobotToolFromQuaternionComponent> _toolsQuaternionByGuid;
        private List<string> _toolNames;

        // contains information on all work objects in file for code generation
        private Dictionary<Guid, WorkObjectComponent> _workObjectsByGuid;
        private List<string> _workObjectNames;

        #region OBSOLETE
        private Dictionary<Guid, OldAbsoluteJointMovementComponent> _oldJointTargetsByGuid;
        private Dictionary<Guid, OldTargetComponent> _oldTargetsByGuid;
        private Dictionary<Guid, OldRobotToolFromDataEulerComponent> _oldToolsEulerByGuid;
        private Dictionary<Guid, OldRobotToolFromPlanesComponent> _oldRobotToolFromPlanesGuid;
        private Dictionary<Guid, OldRobotToolFromQuaternionComponent> _oldToolsQuaternionByGuid;
        private Dictionary<Guid, OldRobotToolFromQuaternionComponent2> _oldToolsQuaternionByGuid2;
        private Dictionary<Guid, OldWorkObjectComponent> _oldWorkObjectsByGuid;
        #endregion

        #endregion

        #region constructors
        /// <summary>
        /// Creates an empty object manager. 
        /// </summary>
        public ObjectManager()
        {
            _jointTargetsByGuid = new Dictionary<Guid, AbsoluteJointMovementComponent>();
            _targetsByGuid = new Dictionary<Guid, TargetComponent>();
            _targetNames = new List<string>();

            _speedDatasByGuid = new Dictionary<Guid, SpeedDataComponent>();
            _speedDataNames = new List<string>();
            _speedDataNames.AddRange(SpeedData.ValidPredefinedNames.ToList());

            _zoneDatasByGuid = new Dictionary<Guid, ZoneDataComponent>();
            _zoneDataNames = new List<string>();
            _zoneDataNames.AddRange(ZoneData.ValidPredefinedNames.ToList());

            _externalLinearAxesByGuid = new Dictionary<Guid, ExternalLinearAxisComponent>();
            _externalRotationalAxesByGuid = new Dictionary<Guid, ExternalRotationalAxisComponent>();
            _axisNames = new List<string>();

            _toolsPlanesByGuid = new Dictionary<Guid, RobotToolFromPlanesComponent>();
            _toolsQuaternionByGuid = new Dictionary<Guid, RobotToolFromQuaternionComponent>();
            _toolNames = new List<string>() { "tool0" };

            _workObjectsByGuid = new Dictionary<Guid, WorkObjectComponent>();
            _workObjectNames = new List<string>() { "wobj0" };

            #region OBSOLETE
            _oldJointTargetsByGuid = new Dictionary<Guid, OldAbsoluteJointMovementComponent>();
            _oldTargetsByGuid = new Dictionary<Guid, OldTargetComponent>();
            _oldToolsEulerByGuid = new Dictionary<Guid, OldRobotToolFromDataEulerComponent>();
            _oldRobotToolFromPlanesGuid = new Dictionary<Guid, OldRobotToolFromPlanesComponent>();
            _oldToolsQuaternionByGuid = new Dictionary<Guid, OldRobotToolFromQuaternionComponent>();
            _oldToolsQuaternionByGuid2 = new Dictionary<Guid, OldRobotToolFromQuaternionComponent2>();
            _oldWorkObjectsByGuid = new Dictionary<Guid, OldWorkObjectComponent>();
            #endregion
        }
        #endregion

        #region methods
        /// <summary>
        /// Gets all the robot tools that are stored in the object mananger
        /// </summary>
        /// <returns> A list with all the robot tools that are stored in the object mananger. </returns>
        public List<RobotTool> GetRobotTools()
        {
            // Enpty listt
            List<RobotTool> robotTools = new List<RobotTool>();

            // Add robot tools that are created from Planes
            foreach (KeyValuePair<Guid, RobotToolFromPlanesComponent> entry in _toolsPlanesByGuid)
            {
                robotTools.Add(entry.Value.RobotTool);
            }

            // Add robot tools that are created from Quaternion data
            foreach (KeyValuePair<Guid, RobotToolFromQuaternionComponent> entry in _toolsQuaternionByGuid)
            {
                robotTools.Add(entry.Value.RobotTool);
            }

            #region OBSOLETE
            // Add robot tools that are created from Euler data
            foreach (KeyValuePair<Guid, OldRobotToolFromDataEulerComponent> entry in _oldToolsEulerByGuid)
            {
                robotTools.Add(entry.Value.RobotTool);
            }

            // Add robot tools that are created from Planes
            foreach (KeyValuePair<Guid, OldRobotToolFromPlanesComponent> entry in _oldRobotToolFromPlanesGuid)
            {
                robotTools.Add(entry.Value.RobotTool);
            }

            // Add robot tools that are created from Quaternion data
            foreach (KeyValuePair<Guid, OldRobotToolFromQuaternionComponent> entry in _oldToolsQuaternionByGuid)
            {
                robotTools.Add(entry.Value.RobotTool);
            }

            // Add robot tools that are created from Quaternion data
            foreach (KeyValuePair<Guid, OldRobotToolFromQuaternionComponent2> entry in _oldToolsQuaternionByGuid2)
            {
                robotTools.Add(entry.Value.RobotTool);
            }
            #endregion

            // Sort based on name
            robotTools = robotTools.OrderBy(x => x.Name).ToList();

            // Return
            return robotTools;
        }

        /// <summary>
        /// Gets all the work objects that are stored in the object mananger
        /// </summary>
        /// <returns> A list with all the work objects that are stored in the object mananger. </returns>
        public List<WorkObject> GetWorkObjects()
        {
            // Empty list
            List<WorkObject> workObjects = new List<WorkObject>();

            // Add all the work objects from old component
            foreach (KeyValuePair<Guid, OldWorkObjectComponent> entry in _oldWorkObjectsByGuid)
            {
                workObjects.AddRange(entry.Value.WorkObjects);
            }

            // Add all work objects from new component
            foreach (KeyValuePair<Guid, WorkObjectComponent> entry in _workObjectsByGuid)
            {
                workObjects.AddRange(entry.Value.WorkObjects);
            }

            // Sort based on name
            workObjects = workObjects.OrderBy(x => x.Name).ToList();

            // Return
            return workObjects;
        }

        /// <summary>
        /// Gets all the external axes that are stored in the object mananger
        /// </summary>
        /// <returns> A list with all external axes that are stored in the object mananger. </returns>
        public List<ExternalAxis> GetExternalAxes()
        {
            // Empty list
            List<ExternalAxis> externalAxes = new List<ExternalAxis>();

            // Adds all the external linear axes as external axis
            foreach (KeyValuePair<Guid, ExternalLinearAxisComponent> entry in _externalLinearAxesByGuid)
            {
                externalAxes.Add(entry.Value.ExternalAxis);
            }

            // Adds all the external rotational axes as external axis
            foreach (KeyValuePair<Guid, ExternalRotationalAxisComponent> entry in _externalRotationalAxesByGuid)
            {
                externalAxes.Add(entry.Value.ExternalAxis);
            }

            // Sort based on name
            externalAxes = externalAxes.OrderBy(x => x.Name).ToList();

            // Return
            return externalAxes;
        }

        /// <summary>
        /// Gets all the absolute joint movements that are stored in the object mananger
        /// </summary>
        /// <returns> A list with all the absolute joint movements that are stored in the object mananger. </returns>
        public List<AbsoluteJointMovement> GetAbsoluteJointMovements()
        {
            // Empty list
            List<AbsoluteJointMovement> jointMomvements = new List<AbsoluteJointMovement>();

            // Add all the absolute joint movements
            foreach (KeyValuePair<Guid, AbsoluteJointMovementComponent> entry in _jointTargetsByGuid)
            {
                jointMomvements.AddRange(entry.Value.AbsoluteJointMovements);
            }

            // Sort based on name
            jointMomvements = jointMomvements.OrderBy(x => x.Name).ToList();

            // Return
            return jointMomvements;
        }

        /// <summary>
        /// Gets all the targets that are stored in the object mananger
        /// </summary>
        /// <returns> A list with all the targets that are stored in the object mananger. </returns>
        public List<Target> GetTargets()
        {
            // Empty list
            List<Target> targets = new List<Target>();

            // Add all the targets
            foreach (KeyValuePair<Guid, TargetComponent> entry in _targetsByGuid)
            {
                targets.AddRange(entry.Value.Targets);
            }

            // Sort based on name
            targets = targets.OrderBy(x => x.Name).ToList();

            // Return
            return targets;
        }

        /// <summary>
        /// Gets all the speed datas that are stored in the object mananger
        /// </summary>
        /// <returns> A list with all the speed datas that are stored in the object mananger. </returns>
        public List<SpeedData> GetSpeedDatas()
        {
            // Empty list
            List<SpeedData> speeddatas = new List<SpeedData>();

            // Add all the speed datas
            foreach (KeyValuePair<Guid, SpeedDataComponent> entry in _speedDatasByGuid)
            {
                speeddatas.AddRange(entry.Value.SpeedDatas);
            }

            // Sort based on name
            speeddatas = speeddatas.OrderBy(x => x.Name).ToList();

            // Return
            return speeddatas;
        }

        /// <summary>
        /// Gets all the zone datas that are stored in the object mananger
        /// </summary>
        /// <returns> A list with all the zone datas that are stored in the object mananger. </returns>
        public List<ZoneData> GetZoneDatas()
        {
            // Empty list
            List<ZoneData> zonedatas = new List<ZoneData>();

            // Add all the zone datas
            foreach (KeyValuePair<Guid, ZoneDataComponent> entry in _zoneDatasByGuid)
            {
                zonedatas.AddRange(entry.Value.ZoneDatas);
            }

            // Sort based on name
            zonedatas = zonedatas.OrderBy(x => x.Name).ToList();

            // Return
            return zonedatas;
        }

        /// <summary>
        /// Runs SolveInstance on all other Robot Tools to check if robot tool names are unique.
        /// </summary>
        public void UpdateRobotTools()
        {
            // Run SolveInstance on other Tools with no unique Name to check if their name is now available
            foreach (KeyValuePair<Guid, RobotToolFromPlanesComponent> entry in ToolsPlanesByGuid)
            {
                entry.Value.ExpireSolution(true);
            }
            foreach (KeyValuePair<Guid, RobotToolFromQuaternionComponent> entry in ToolsQuaternionByGuid)
            {
                entry.Value.ExpireSolution(true);
            }

            // Run SolveInstance on other obolete Tools with no unique Name to check if their name is now available
            // --- remove in version 0.1.000
            foreach (KeyValuePair<Guid, OldRobotToolFromDataEulerComponent> entry in OldToolsEulerByGuid)
            {
                entry.Value.ExpireSolution(true);
            }

            foreach (KeyValuePair<Guid, OldRobotToolFromPlanesComponent> entry in OldRobotToolFromPlanesGuid)
            {
                entry.Value.ExpireSolution(true);
            }

            foreach (KeyValuePair<Guid, OldRobotToolFromQuaternionComponent> entry in OldToolsQuaternionByGuid)
            {
                entry.Value.ExpireSolution(true);
            }

            foreach (KeyValuePair<Guid, OldRobotToolFromQuaternionComponent2> entry in OldToolsQuaternionByGuid2)
            {
                entry.Value.ExpireSolution(true);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Dictionary with all the Target components used in this object manager. 
        /// The components are stored based on there unique GUID.
        /// </summary>
        public Dictionary<Guid, AbsoluteJointMovementComponent> JointTargetsByGuid
        {
            get { return _jointTargetsByGuid; }
        }

        /// <summary>
        /// Dictionary with all the Target components used in this object manager. 
        /// The components are stored based on there unique GUID.
        /// </summary>
        public Dictionary<Guid, TargetComponent> TargetsByGuid
        {
            get { return _targetsByGuid; }
        }

        /// <summary>
        /// A list with all the unique 'Target names in this object manager
        /// </summary>
        public List<string> TargetNames
        {
            get { return _targetNames; }
        }

        /// <summary>
        /// Dictionary with all the External Linear Axis components used in this object manager. 
        /// The components are stored based on there unique GUID.
        /// </summary>
        public Dictionary<Guid, ExternalLinearAxisComponent> ExternalLinearAxesByGuid
        {
            get { return _externalLinearAxesByGuid; }
        }

        /// <summary>
        /// Dictionary with all the External Rotational Axis components used in this object manager. 
        /// The components are stored based on there unique GUID.
        /// </summary>
        public Dictionary<Guid, ExternalRotationalAxisComponent> ExternalRotationalAxesByGuid
        {
            get { return _externalRotationalAxesByGuid; }
        }

        /// <summary>
        /// A list with all the unique External Axis names in this object manager
        /// </summary>
        public List<string> ExternalAxisNames
        {
            get { return _axisNames; }
        }

        /// <summary>
        /// Dictionary with all the Speed Data components used in this object manager. 
        /// The components are stored based on there unique GUID.
        /// </summary>
        public Dictionary<Guid, SpeedDataComponent> SpeedDatasByGuid
        {
            get { return _speedDatasByGuid; }
        }

        /// <summary>
        /// A list with all the unique Speed Data names in this object manager
        /// </summary>
        public List<string> SpeedDataNames
        {
            get { return _speedDataNames; }
        }

        /// <summary>
        /// Dictionary with all the Zone Data components used in this object manager. 
        /// The components are stored based on there unique GUID.
        /// </summary>
        public Dictionary<Guid, ZoneDataComponent> ZoneDatasByGuid
        {
            get { return _zoneDatasByGuid; }
        }

        /// <summary>
        /// A list with all the unique Zone Data names in this object manager
        /// </summary>
        public List<string> ZoneDataNames
        {
            get { return _zoneDataNames; }
        }

        /// <summary>
        /// Dictionary with all the Robot Tools created from Planes components used in this object manager. 
        /// The components are stored based on there unique GUID.
        /// </summary>
        public Dictionary<Guid, RobotToolFromPlanesComponent> ToolsPlanesByGuid
        {
            get { return _toolsPlanesByGuid; }
        }

        /// <summary>
        /// Dictionary with all the Robot Tools created from Quaternion data components used in this object manager. 
        /// The components are stored based on there unique GUID.
        /// </summary>
        public Dictionary<Guid, RobotToolFromQuaternionComponent> ToolsQuaternionByGuid
        {
            get { return _toolsQuaternionByGuid; }
        }

        /// <summary>
        /// A list with all the unique Robot Tool names in this object manager
        /// </summary>
        public List<string> ToolNames
        {
            get { return _toolNames; }
        }

        /// <summary>
        /// Dictionary with all the Work Object components used in this object manager. 
        /// The components are stored based on there unique GUID.
        /// </summary>
        public Dictionary<Guid, WorkObjectComponent> WorkObjectsByGuid
        {
            get { return _workObjectsByGuid; }
        }

        /// <summary>
        /// A list with all the unique Work Object names in this object manager
        /// </summary>
        public List<string> WorkObjectNames 
        {
            get { return _workObjectNames; }
        }

        #region OBSOLETE
        /// <summary>
        /// OBSOLETE: Used for old Absolute Joint Movement component. Will be removed in the future.
        /// </summary>
        public Dictionary<Guid, OldAbsoluteJointMovementComponent> OldJointTargetsByGuid
        {
            get { return _oldJointTargetsByGuid; }
        }

        /// <summary>
        /// OBSOLETE: Used for old Target component. Will be removed in the future.
        /// </summary>
        public Dictionary<Guid, OldTargetComponent> OldTargetsByGuid
        {
            get { return _oldTargetsByGuid; }
        }

        /// <summary>
        /// OBSOLETE: Used for old Tool components.Will be removed in the future.
        /// </summary>
        public Dictionary<Guid, OldRobotToolFromDataEulerComponent> OldToolsEulerByGuid
        {
            get { return _oldToolsEulerByGuid; }
        }

        public Dictionary<Guid, OldRobotToolFromPlanesComponent> OldRobotToolFromPlanesGuid
        {
            get { return _oldRobotToolFromPlanesGuid; }
        }

        public Dictionary<Guid, OldRobotToolFromQuaternionComponent> OldToolsQuaternionByGuid
        {
            get { return _oldToolsQuaternionByGuid; }
        }

        public Dictionary<Guid, OldRobotToolFromQuaternionComponent2> OldToolsQuaternionByGuid2 
        {
            get { return _oldToolsQuaternionByGuid2; }
        }

        /// <summary>
        /// OBSOLETE: Used for old Work Object component.Will be removed in the future.
        /// </summary>
        public Dictionary<Guid, OldWorkObjectComponent> OldWorkObjectsByGuid
        {
            get { return _oldWorkObjectsByGuid; }
        }


        #endregion

        #endregion
    }
}
