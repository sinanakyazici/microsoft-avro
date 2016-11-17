﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 12.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Microsoft.Hadoop.Avro.Utils.Templates
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Hadoop.Avro.Schema;
    using Microsoft.Hadoop.Avro.Utils;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    internal partial class ClassTemplate : ClassTemplateBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("//<auto-generated />\r\nnamespace ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Utilities.GetNamespace(this, this.Schema.Namespace)));
            this.Write("\r\n{\r\n    using System;\r\n    using System.Collections.Generic;\r\n    using System.R" +
                    "untime.Serialization;\r\n    using Microsoft.Hadoop.Avro;\r\n\r\n    /// <summary>\r\n  " +
                    "  /// Used to serialize and deserialize Avro record ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Utilities.Validate(this.Schema.FullName)));
            this.Write(".\r\n    /// </summary>\r\n    [DataContract(Namespace = \"");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Schema.Namespace));
            this.Write("\")]");
 GenerateKnownTypesAttributes(((RecordSchema)this.Schema).Fields); 
            this.Write("\r\n    public partial class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Utilities.Validate(this.Schema.Name)));
            this.Write("\r\n    {\r\n        private const string JsonSchema = @\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Schema.ToString().Replace("\"", "\"\"")));
            this.Write("\";\r\n\r\n        /// <summary>\r\n        /// Gets the schema.\r\n        /// </summary>" +
                    "\r\n        public static string Schema\r\n        {\r\n            get\r\n            {" +
                    "\r\n                return JsonSchema;\r\n            }\r\n        }\r\n");
 foreach (var field in ((RecordSchema)this.Schema).Fields)
    {

            this.Write("      \r\n        /// <summary>\r\n        /// Gets or sets the ");
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name));
            this.Write(" field.\r\n        /// </summary>\r\n        [DataMember]");
 GenerateTypeAttributes(field.TypeSchema); 
            this.Write("\r\n        public ");
 GenerateType(field.TypeSchema, true, false, false); 
            this.Write(" ");
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name));
            this.Write(" { get; set; }\r\n        ");
  
    }

            this.Write("        \r\n        /// <summary>\r\n        /// Initializes a new instance of the <s" +
                    "ee cref=\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(Utilities.Validate(this.Schema.Name)));
            this.Write("\"/> class.\r\n        /// </summary>\r\n        public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Schema.Name));
            this.Write("()\r\n        {\r\n");
  foreach (var field in ((RecordSchema)this.Schema).Fields)
    {
        if(field.HasDefaultValue)
        {
            
            this.Write("            this.");
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name));
            this.Write(" = ");
 GenerateDefaultValue(field.TypeSchema, field.DefaultValue); 
            this.Write(";\r\n");
      }
    } 
            this.Write("        }\r\n");
 if(((RecordSchema)this.Schema).Fields.Any()) { 
            this.Write("\r\n        /// <summary>\r\n        /// Initializes a new instance of the <see cref=" +
                    "\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(Utilities.Validate(this.Schema.Name)));
            this.Write("\"/> class.\r\n        /// </summary>\r\n");
  foreach (var field in ((RecordSchema)this.Schema).Fields)
    {
        
            this.Write("        /// <param name=\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.FirstLetterToLower()));
            this.Write("\">The ");
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.FirstLetterToLower()));
            this.Write(".</param>\r\n");

}
            this.Write("        public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Schema.Name));
            this.Write("(");
 var count = ((RecordSchema)this.Schema).Fields.Count; foreach (var field in ((RecordSchema)this.Schema).Fields) { GenerateType(field.TypeSchema, true, false, false);
            this.Write(" ");
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.FirstLetterToLower()));
if(--count > 0) 
            this.Write(", ");
; }
            this.Write(")\r\n        {\r\n");
  foreach (var field in ((RecordSchema)this.Schema).Fields)
    {
            
            this.Write("            this.");
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name));
            this.Write(" = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.FirstLetterToLower()));
            this.Write(";\r\n");
  }   
            this.Write("        }\r\n");
}
            this.Write("    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    internal void GenerateType(TypeSchema typeSchema, bool isDeclaration, bool inAttribute, bool startRhs)
    {
        if (typeSchema is PrimitiveTypeSchema)
        {
            
this.Write(this.ToStringHelper.ToStringWithCulture(Utilities.GetAlias(typeSchema.RuntimeType)));


            return;
        }
        var namedSchema = typeSchema as NamedSchema;
        if (namedSchema != null)
        {
            if(typeSchema is FixedSchema)
            {
                
this.Write("byte[]");


            }
            else
            {
                
this.Write(this.ToStringHelper.ToStringWithCulture(Utilities.Validate(string.Concat(Utilities.GetNamespace(this, namedSchema.Namespace), ".", (namedSchema.Name)))));


            }
            return;
        }
        var mapSchema = typeSchema as MapSchema;
        if (mapSchema != null)
        {
            if(!inAttribute && isDeclaration && !startRhs)
            {
                
this.Write("I");


            }
            
this.Write("Dictionary<string, ");

 GenerateType(mapSchema.ValueSchema, isDeclaration, inAttribute, false); 
this.Write(">");


            return;
        }
        var arraySchema = typeSchema as ArraySchema;
        if (arraySchema != null)
        {
            if(!inAttribute && isDeclaration && !startRhs)
            {
                
this.Write("I");


            }
            
this.Write("List<");

 GenerateType(arraySchema.ItemSchema, isDeclaration, inAttribute, false); 
this.Write(">");


            return;
        }
        var unionSchema = typeSchema as UnionSchema;
        if (unionSchema.Schemas.Count == 2 && unionSchema.Schemas[0] is NullSchema && unionSchema.Schemas[1] is PrimitiveTypeSchema)
        {
            if(unionSchema.Schemas[1] is StringSchema || unionSchema.Schemas[1] is BytesSchema)
            {
                
this.Write(this.ToStringHelper.ToStringWithCulture(Utilities.GetAlias(unionSchema.Schemas[1].RuntimeType)));


            }
            else
            {
                
this.Write("Nullable<");

 GenerateType((dynamic)unionSchema.Schemas[1], isDeclaration, inAttribute, false); 
this.Write(">");


            }
        }
        else if (unionSchema.Schemas.Count == 2 && unionSchema.Schemas[1] is NullSchema && unionSchema.Schemas[0] is PrimitiveTypeSchema)
        {
            if(unionSchema.Schemas[0] is StringSchema || unionSchema.Schemas[0] is BytesSchema)
            {
                
this.Write(this.ToStringHelper.ToStringWithCulture(Utilities.GetAlias(unionSchema.Schemas[0].RuntimeType)));


            }
            else
            {
                
this.Write("Nullable<");

 GenerateType((dynamic)unionSchema.Schemas[0], isDeclaration, inAttribute, false); 
this.Write(">");


            }
        }
        else
        {
            
this.Write("object");

;
        }
    }

    internal void GenerateTypeAttributes(TypeSchema typeSchema)
    {
        var fixedSchema = typeSchema as FixedSchema;
        if(fixedSchema != null)
        {
                
this.Write("\r\n        [AvroFixed(");

this.Write(this.ToStringHelper.ToStringWithCulture(fixedSchema.Size));

this.Write(", \"");

this.Write(this.ToStringHelper.ToStringWithCulture(fixedSchema.Name));

this.Write("\", \"");

this.Write(this.ToStringHelper.ToStringWithCulture(fixedSchema.Namespace));

this.Write("\")]");


        }

        var unionSchema = typeSchema as UnionSchema;
        if(unionSchema == null)
        {
            return;
        }
        if (unionSchema.Schemas.Count == 2 && ((unionSchema.Schemas[0] is NullSchema && unionSchema.Schemas[1] is PrimitiveTypeSchema)
            || (unionSchema.Schemas[1] is NullSchema && unionSchema.Schemas[0] is PrimitiveTypeSchema)))
        {
            return;
        }
        else
        {
            if(unionSchema.Schemas.Any())
            {
                
this.Write("\r\n        [AvroUnion(");


                for (int i = 0; i < unionSchema.Schemas.Count; i++)
                {
                    if(unionSchema.Schemas[i] is NullSchema)
                    {
                    
this.Write("typeof(AvroNull)");


                    }
                    else
                    {
                    
this.Write("typeof(");

 GenerateType(unionSchema.Schemas[i], false, true, false); 
this.Write(")");


                    }
                    if(i < unionSchema.Schemas.Count - 1)
                    {
                        
this.Write(", ");


                    }
                }
                
this.Write(")]");


            }
        }
    }

    internal void GenerateKnownTypesAttributes(IList<RecordField> fields)
    {
        var schemata = new List<TypeSchema>();
        foreach(var field in fields)
        {
            GetKnownTypeSchemata(field.TypeSchema, ref schemata);
        }

        foreach (var schema in schemata)
        {
            
this.Write("\r\n    [KnownType(typeof(");


                GenerateType(schema, true, false, true);
                
this.Write("))]");


        }
    }

    private void GetKnownTypeSchemata(TypeSchema schema, ref List<TypeSchema> result)
    {
        while (true)
        {
            if (result.Any(s => s.ToString() == schema.ToString()))
            {
                return;
            }

            var mapSchema = schema as MapSchema;
            if (mapSchema != null)
            {
                result.Add(schema);
                schema = mapSchema.ValueSchema;
                continue;
            }

            var arraySchema = schema as ArraySchema;
            if (arraySchema != null)
            {
                result.Add(schema);
                schema = arraySchema.ItemSchema;
                continue;
            }
            break;
        }
    }

 private void GenerateDefaultValue(TypeSchema typeSchema, object defaultValue)
        {
            if (typeSchema is IntSchema || typeSchema is LongSchema || typeSchema is BooleanSchema)
            {
                
this.Write(this.ToStringHelper.ToStringWithCulture(defaultValue.ToString().ToLowerInvariant()));


            }
            else if(typeSchema is NullSchema)
            {
                
this.Write("null");


            }
            else if(typeSchema is StringSchema)
            {
                
this.Write("\"");

this.Write(this.ToStringHelper.ToStringWithCulture(defaultValue));

this.Write("\"");


            }
            else if(typeSchema is FloatSchema)
            {
                
this.Write("(float)");

this.Write(this.ToStringHelper.ToStringWithCulture(((float) defaultValue).ToString(CultureInfo.InvariantCulture)));


            }
            else if(typeSchema is DoubleSchema)
            {
                
this.Write(this.ToStringHelper.ToStringWithCulture(((double) defaultValue).ToString(CultureInfo.InvariantCulture)));


            }
            else if(typeSchema is BytesSchema || typeSchema is FixedSchema)
            {
                
this.Write("new byte[] {");


                var asArray = defaultValue as byte[];
                for (int i = 0; i < asArray.Length; i++)
                {
                    
this.Write(" ");

this.Write(this.ToStringHelper.ToStringWithCulture(asArray[i].ToString(CultureInfo.InvariantCulture)));


                    if(i < asArray.Length - 1){
                        
this.Write(",");


                    }
                }
                
this.Write(" }");


            }
            else if (typeSchema is EnumSchema)
            {
                var enumSchema = typeSchema as EnumSchema;
                
this.Write(this.ToStringHelper.ToStringWithCulture(Utilities.Validate(string.Concat(Utilities.GetNamespace(this, enumSchema.Namespace), ".", enumSchema.Name))));

this.Write(".");

this.Write(this.ToStringHelper.ToStringWithCulture((defaultValue as AvroEnum).Value));


            }
            else if(typeSchema is UnionSchema)
            {
                GenerateDefaultValue((dynamic) (typeSchema as UnionSchema).Schemas[0], defaultValue);
            }
            else
            {
                
this.Write("new ");

 GenerateType((dynamic)typeSchema, true, false, true); 
this.Write("{ ");


                if (typeSchema is ArraySchema)
                {
                    var arrayDefaultValues = defaultValue as Array;
                    for (int i = 0; i < arrayDefaultValues.Length; i++)
                    {
                        GenerateDefaultValue(((dynamic) typeSchema).ItemSchema, arrayDefaultValues.GetValue(i));
                        if(i < arrayDefaultValues.Length - 1){
                            
this.Write(",");


                        }
                        
this.Write(" ");


                    }
                }
                else if (typeSchema is MapSchema)
                {
                    var asDictionary = defaultValue as IDictionary<string, object>;
                    int i = 0;
                    foreach (var item in asDictionary)
                    {
                        
this.Write("{ ");

 GenerateDefaultValue(((dynamic) typeSchema).KeySchema, item.Key); 
this.Write(", ");

 GenerateDefaultValue(((dynamic) typeSchema).ValueSchema, item.Value); 
this.Write(" }");


                        if (++i < asDictionary.Count)
                        {
                            
this.Write(",");


                        }
                    }
                }
                else if (typeSchema is RecordSchema)
                {
                    var fields = ((dynamic)defaultValue).Schema.Fields;
                    for (int i = 0; i < fields.Count; i++)
                    {
                        
this.Write(this.ToStringHelper.ToStringWithCulture(Utilities.Validate(fields[i].Name)));

this.Write(" = ");

 GenerateDefaultValue((dynamic) fields[i].TypeSchema, ((dynamic)defaultValue)[fields[i].Name]);
                        if(i < fields.Count - 1){
                            
this.Write(",");


                        }
                    }
                }
                
this.Write("}");


            }
        }

    }
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    internal class ClassTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            CompilerError error = new CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            CompilerError error = new CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetTypeInfo().GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}