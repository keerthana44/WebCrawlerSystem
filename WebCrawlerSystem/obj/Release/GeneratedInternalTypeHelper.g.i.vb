﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

<Assembly: System.Windows.Markup.RootNamespaceAttribute("WebCrawlerSystem")> 

Namespace XamlGeneratedNamespace
    
    '''<summary>
    '''GeneratedInternalTypeHelper
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Public NotInheritable Class GeneratedInternalTypeHelper
        Inherits System.Windows.Markup.InternalTypeHelper
        
        '''<summary>
        '''CreateInstance
        '''</summary>
        Protected Overrides Function CreateInstance(ByVal type As System.Type, ByVal culture As System.Globalization.CultureInfo) As Object
            Return System.Activator.CreateInstance(type, ((System.Reflection.BindingFlags.[Public] Or System.Reflection.BindingFlags.NonPublic)  _
                            Or (System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.CreateInstance)), Nothing, Nothing, culture)
        End Function
        
        '''<summary>
        '''GetPropertyValue
        '''</summary>
        Protected Overrides Function GetPropertyValue(ByVal propertyInfo As System.Reflection.PropertyInfo, ByVal target As Object, ByVal culture As System.Globalization.CultureInfo) As Object
            Return propertyInfo.GetValue(target, System.Reflection.BindingFlags.[Default], Nothing, Nothing, culture)
        End Function
        
        '''<summary>
        '''SetPropertyValue
        '''</summary>
        Protected Overrides Sub SetPropertyValue(ByVal propertyInfo As System.Reflection.PropertyInfo, ByVal target As Object, ByVal value As Object, ByVal culture As System.Globalization.CultureInfo)
            propertyInfo.SetValue(target, value, System.Reflection.BindingFlags.[Default], Nothing, Nothing, culture)
        End Sub
        
        '''<summary>
        '''CreateDelegate
        '''</summary>
        Protected Overrides Function CreateDelegate(ByVal delegateType As System.Type, ByVal target As Object, ByVal handler As String) As System.[Delegate]
            Return CType(target.GetType.InvokeMember("_CreateDelegate", (System.Reflection.BindingFlags.InvokeMethod  _
                            Or (System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance)), Nothing, target, New Object() {delegateType, handler}, Nothing),System.[Delegate])
        End Function
        
        '''<summary>
        '''AddEventHandler
        '''</summary>
        Protected Overrides Sub AddEventHandler(ByVal eventInfo As System.Reflection.EventInfo, ByVal target As Object, ByVal handler As System.[Delegate])
            eventInfo.AddEventHandler(target, handler)
        End Sub
    End Class
End Namespace

