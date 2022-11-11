/* ========================================================================
 * Copyright (c) 2005-2021 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace ConveyorOpcUAServer
{
    #region Method Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <remarks />
        public const uint TripleHType_StartProcess = 46;

        /// <remarks />
        public const uint TripleHType_StopProcess = 47;

        /// <remarks />
        public const uint TripleH1_StartProcess = 64;

        /// <remarks />
        public const uint TripleH1_StopProcess = 65;
    }
    #endregion

    #region Object Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <remarks />
        public const uint ConveyorType_Motor1 = 16;

        /// <remarks />
        public const uint ConveyorType_Motor2 = 23;

        /// <remarks />
        public const uint TripleHType_Conveyor = 31;

        /// <remarks />
        public const uint TripleHType_Conveyor_Motor1 = 32;

        /// <remarks />
        public const uint TripleHType_Conveyor_Motor2 = 39;

        /// <remarks />
        public const uint TripleH1 = 48;

        /// <remarks />
        public const uint TripleH1_Conveyor = 49;

        /// <remarks />
        public const uint TripleH1_Conveyor_Motor1 = 50;

        /// <remarks />
        public const uint TripleH1_Conveyor_Motor2 = 57;
    }
    #endregion

    #region ObjectType Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <remarks />
        public const uint GenericMotorType = 1;

        /// <remarks />
        public const uint ThreePharesMotor = 8;

        /// <remarks />
        public const uint ConveyorType = 15;

        /// <remarks />
        public const uint TripleHType = 30;
    }
    #endregion

    #region Variable Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <remarks />
        public const uint GenericMotorType_Speed = 2;

        /// <remarks />
        public const uint GenericMotorType_Speed_EURange = 6;

        /// <remarks />
        public const uint ThreePharesMotor_Speed_EURange = 13;

        /// <remarks />
        public const uint ConveyorType_Motor1_Speed = 17;

        /// <remarks />
        public const uint ConveyorType_Motor1_Speed_EURange = 21;

        /// <remarks />
        public const uint ConveyorType_Motor2_Speed = 24;

        /// <remarks />
        public const uint ConveyorType_Motor2_Speed_EURange = 28;

        /// <remarks />
        public const uint TripleHType_Conveyor_Motor1_Speed = 33;

        /// <remarks />
        public const uint TripleHType_Conveyor_Motor1_Speed_EURange = 37;

        /// <remarks />
        public const uint TripleHType_Conveyor_Motor2_Speed = 40;

        /// <remarks />
        public const uint TripleHType_Conveyor_Motor2_Speed_EURange = 44;

        /// <remarks />
        public const uint TripleH1_Conveyor_Motor1_Speed = 51;

        /// <remarks />
        public const uint TripleH1_Conveyor_Motor1_Speed_EURange = 55;

        /// <remarks />
        public const uint TripleH1_Conveyor_Motor2_Speed = 58;

        /// <remarks />
        public const uint TripleH1_Conveyor_Motor2_Speed_EURange = 62;
    }
    #endregion

    #region Method Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class MethodIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId TripleHType_StartProcess = new ExpandedNodeId(Methods.TripleHType_StartProcess, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleHType_StopProcess = new ExpandedNodeId(Methods.TripleHType_StopProcess, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleH1_StartProcess = new ExpandedNodeId(Methods.TripleH1_StartProcess, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleH1_StopProcess = new ExpandedNodeId(Methods.TripleH1_StopProcess, Namespaces.TripleH);
    }
    #endregion

    #region Object Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId ConveyorType_Motor1 = new ExpandedNodeId(Objects.ConveyorType_Motor1, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId ConveyorType_Motor2 = new ExpandedNodeId(Objects.ConveyorType_Motor2, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleHType_Conveyor = new ExpandedNodeId(Objects.TripleHType_Conveyor, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleHType_Conveyor_Motor1 = new ExpandedNodeId(Objects.TripleHType_Conveyor_Motor1, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleHType_Conveyor_Motor2 = new ExpandedNodeId(Objects.TripleHType_Conveyor_Motor2, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleH1 = new ExpandedNodeId(Objects.TripleH1, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleH1_Conveyor = new ExpandedNodeId(Objects.TripleH1_Conveyor, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleH1_Conveyor_Motor1 = new ExpandedNodeId(Objects.TripleH1_Conveyor_Motor1, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleH1_Conveyor_Motor2 = new ExpandedNodeId(Objects.TripleH1_Conveyor_Motor2, Namespaces.TripleH);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId GenericMotorType = new ExpandedNodeId(ObjectTypes.GenericMotorType, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId ThreePharesMotor = new ExpandedNodeId(ObjectTypes.ThreePharesMotor, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId ConveyorType = new ExpandedNodeId(ObjectTypes.ConveyorType, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleHType = new ExpandedNodeId(ObjectTypes.TripleHType, Namespaces.TripleH);
    }
    #endregion

    #region Variable Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId GenericMotorType_Speed = new ExpandedNodeId(Variables.GenericMotorType_Speed, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId GenericMotorType_Speed_EURange = new ExpandedNodeId(Variables.GenericMotorType_Speed_EURange, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId ThreePharesMotor_Speed_EURange = new ExpandedNodeId(Variables.ThreePharesMotor_Speed_EURange, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId ConveyorType_Motor1_Speed = new ExpandedNodeId(Variables.ConveyorType_Motor1_Speed, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId ConveyorType_Motor1_Speed_EURange = new ExpandedNodeId(Variables.ConveyorType_Motor1_Speed_EURange, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId ConveyorType_Motor2_Speed = new ExpandedNodeId(Variables.ConveyorType_Motor2_Speed, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId ConveyorType_Motor2_Speed_EURange = new ExpandedNodeId(Variables.ConveyorType_Motor2_Speed_EURange, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleHType_Conveyor_Motor1_Speed = new ExpandedNodeId(Variables.TripleHType_Conveyor_Motor1_Speed, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleHType_Conveyor_Motor1_Speed_EURange = new ExpandedNodeId(Variables.TripleHType_Conveyor_Motor1_Speed_EURange, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleHType_Conveyor_Motor2_Speed = new ExpandedNodeId(Variables.TripleHType_Conveyor_Motor2_Speed, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleHType_Conveyor_Motor2_Speed_EURange = new ExpandedNodeId(Variables.TripleHType_Conveyor_Motor2_Speed_EURange, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleH1_Conveyor_Motor1_Speed = new ExpandedNodeId(Variables.TripleH1_Conveyor_Motor1_Speed, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleH1_Conveyor_Motor1_Speed_EURange = new ExpandedNodeId(Variables.TripleH1_Conveyor_Motor1_Speed_EURange, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleH1_Conveyor_Motor2_Speed = new ExpandedNodeId(Variables.TripleH1_Conveyor_Motor2_Speed, Namespaces.TripleH);

        /// <remarks />
        public static readonly ExpandedNodeId TripleH1_Conveyor_Motor2_Speed_EURange = new ExpandedNodeId(Variables.TripleH1_Conveyor_Motor2_Speed_EURange, Namespaces.TripleH);
    }
    #endregion

    #region BrowseName Declarations
    /// <remarks />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class BrowseNames
    {
        /// <remarks />
        public const string Conveyor = "Conveyor01";

        /// <remarks />
        public const string ConveyorType = "ConveyorType";

        /// <remarks />
        public const string GenericMotorType = "GenericMotorType";

        /// <remarks />
        public const string Motor1 = "Motor01";

        /// <remarks />
        public const string Motor2 = "Motor02";

        /// <remarks />
        public const string Speed = "Speed";

        /// <remarks />
        public const string StartProcess = "StartProcess";

        /// <remarks />
        public const string StopProcess = "StopProcess";

        /// <remarks />
        public const string ThreePharesMotor = "ThreePharesMotor";

        /// <remarks />
        public const string TripleH1 = "Triple-H Server";

        /// <remarks />
        public const string TripleHType = "TripleHType";
    }
    #endregion

    #region Namespace Declarations
    /// <remarks />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for the TripleH namespace (.NET code namespace is 'TripleH').
        /// </summary>
        public const string TripleH = "http://opcfoundation.org/TripleH";
    }
    #endregion
}