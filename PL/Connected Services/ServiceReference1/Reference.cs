﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/SL_WCF")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Repartidor))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.UnidadEntrega))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.EstatusUnidad))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Exception))]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CorrectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Exception ExField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] ObjectsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Correct {
            get {
                return this.CorrectField;
            }
            set {
                if ((this.CorrectField.Equals(value) != true)) {
                    this.CorrectField = value;
                    this.RaisePropertyChanged("Correct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Exception Ex {
            get {
                return this.ExField;
            }
            set {
                if ((object.ReferenceEquals(this.ExField, value) != true)) {
                    this.ExField = value;
                    this.RaisePropertyChanged("Ex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Object {
            get {
                return this.ObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectField, value) != true)) {
                    this.ObjectField = value;
                    this.RaisePropertyChanged("Object");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] Objects {
            get {
                return this.ObjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectsField, value) != true)) {
                    this.ObjectsField = value;
                    this.RaisePropertyChanged("Objects");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IRepartidorServicio")]
    public interface IRepartidorServicio {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidorServicio/Add", ReplyAction="http://tempuri.org/IRepartidorServicio/AddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL.ServiceReference1.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.EstatusUnidad))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        PL.ServiceReference1.Result Add(ML.Repartidor repartidor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidorServicio/Add", ReplyAction="http://tempuri.org/IRepartidorServicio/AddResponse")]
        System.Threading.Tasks.Task<PL.ServiceReference1.Result> AddAsync(ML.Repartidor repartidor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidorServicio/Delete", ReplyAction="http://tempuri.org/IRepartidorServicio/DeleteResponse")]
        PL.ServiceReference1.Result Delete(int idRepartidor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidorServicio/Delete", ReplyAction="http://tempuri.org/IRepartidorServicio/DeleteResponse")]
        System.Threading.Tasks.Task<PL.ServiceReference1.Result> DeleteAsync(int idRepartidor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidorServicio/Update", ReplyAction="http://tempuri.org/IRepartidorServicio/UpdateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL.ServiceReference1.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.EstatusUnidad))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        PL.ServiceReference1.Result Update(ML.Repartidor repartidor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidorServicio/Update", ReplyAction="http://tempuri.org/IRepartidorServicio/UpdateResponse")]
        System.Threading.Tasks.Task<PL.ServiceReference1.Result> UpdateAsync(ML.Repartidor repartidor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidorServicio/GetAll", ReplyAction="http://tempuri.org/IRepartidorServicio/GetAllResponse")]
        PL.ServiceReference1.Result GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidorServicio/GetAll", ReplyAction="http://tempuri.org/IRepartidorServicio/GetAllResponse")]
        System.Threading.Tasks.Task<PL.ServiceReference1.Result> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidorServicio/GetById", ReplyAction="http://tempuri.org/IRepartidorServicio/GetByIdResponse")]
        PL.ServiceReference1.Result GetById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRepartidorServicio/GetById", ReplyAction="http://tempuri.org/IRepartidorServicio/GetByIdResponse")]
        System.Threading.Tasks.Task<PL.ServiceReference1.Result> GetByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRepartidorServicioChannel : PL.ServiceReference1.IRepartidorServicio, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RepartidorServicioClient : System.ServiceModel.ClientBase<PL.ServiceReference1.IRepartidorServicio>, PL.ServiceReference1.IRepartidorServicio {
        
        public RepartidorServicioClient() {
        }
        
        public RepartidorServicioClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RepartidorServicioClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RepartidorServicioClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RepartidorServicioClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PL.ServiceReference1.Result Add(ML.Repartidor repartidor) {
            return base.Channel.Add(repartidor);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReference1.Result> AddAsync(ML.Repartidor repartidor) {
            return base.Channel.AddAsync(repartidor);
        }
        
        public PL.ServiceReference1.Result Delete(int idRepartidor) {
            return base.Channel.Delete(idRepartidor);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReference1.Result> DeleteAsync(int idRepartidor) {
            return base.Channel.DeleteAsync(idRepartidor);
        }
        
        public PL.ServiceReference1.Result Update(ML.Repartidor repartidor) {
            return base.Channel.Update(repartidor);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReference1.Result> UpdateAsync(ML.Repartidor repartidor) {
            return base.Channel.UpdateAsync(repartidor);
        }
        
        public PL.ServiceReference1.Result GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReference1.Result> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public PL.ServiceReference1.Result GetById(int id) {
            return base.Channel.GetById(id);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReference1.Result> GetByIdAsync(int id) {
            return base.Channel.GetByIdAsync(id);
        }
    }
}
