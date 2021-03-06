/**
 * Autogenerated by Thrift Compiler (0.8.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Transport;
namespace VersionExample
{
  public class ClientService {
    public interface Iface {
      bool fooEx(int num);
      bool bar();
    }

    public class Client : Iface {
      public Client(TProtocol prot) : this(prot, prot)
      {
      }

      public Client(TProtocol iprot, TProtocol oprot)
      {
        iprot_ = iprot;
        oprot_ = oprot;
      }

      protected TProtocol iprot_;
      protected TProtocol oprot_;
      protected int seqid_;

      public TProtocol InputProtocol
      {
        get { return iprot_; }
      }
      public TProtocol OutputProtocol
      {
        get { return oprot_; }
      }


      public bool fooEx(int num)
      {
        send_fooEx(num);
        return recv_fooEx();
      }

      public void send_fooEx(int num)
      {
        oprot_.WriteMessageBegin(new TMessage("fooEx", TMessageType.Call, seqid_));
        fooEx_args args = new fooEx_args();
        args.Num = num;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        oprot_.Transport.Flush();
      }

      public bool recv_fooEx()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        fooEx_result result = new fooEx_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "fooEx failed: unknown result");
      }

      public bool bar()
      {
        send_bar();
        return recv_bar();
      }

      public void send_bar()
      {
        oprot_.WriteMessageBegin(new TMessage("bar", TMessageType.Call, seqid_));
        bar_args args = new bar_args();
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        oprot_.Transport.Flush();
      }

      public bool recv_bar()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        bar_result result = new bar_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "bar failed: unknown result");
      }

    }
    public class Processor : TProcessor {
      public Processor(Iface iface)
      {
        iface_ = iface;
        processMap_["fooEx"] = fooEx_Process;
        processMap_["bar"] = bar_Process;
      }

      protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
      private Iface iface_;
      protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

      public bool Process(TProtocol iprot, TProtocol oprot)
      {
        try
        {
          TMessage msg = iprot.ReadMessageBegin();
          ProcessFunction fn;
          processMap_.TryGetValue(msg.Name, out fn);
          if (fn == null) {
            TProtocolUtil.Skip(iprot, TType.Struct);
            iprot.ReadMessageEnd();
            TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
            oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
            x.Write(oprot);
            oprot.WriteMessageEnd();
            oprot.Transport.Flush();
            return true;
          }
          fn(msg.SeqID, iprot, oprot);
        }
        catch (IOException)
        {
          return false;
        }
        return true;
      }

      public void fooEx_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        fooEx_args args = new fooEx_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        fooEx_result result = new fooEx_result();
        result.Success = iface_.fooEx(args.Num);
        oprot.WriteMessageBegin(new TMessage("fooEx", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void bar_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        bar_args args = new bar_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        bar_result result = new bar_result();
        result.Success = iface_.bar();
        oprot.WriteMessageBegin(new TMessage("bar", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

    }


    [Serializable]
    public partial class fooEx_args : TBase
    {
      private int _num;

      public int Num
      {
        get
        {
          return _num;
        }
        set
        {
          __isset.num = true;
          this._num = value;
        }
      }


      public Isset __isset;
      [Serializable]
      public struct Isset {
        public bool num;
      }

      public fooEx_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.I32) {
                Num = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("fooEx_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.num) {
          field.Name = "num";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Num);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("fooEx_args(");
        sb.Append("Num: ");
        sb.Append(Num);
        sb.Append(")");
        return sb.ToString();
      }

    }


    [Serializable]
    public partial class fooEx_result : TBase
    {
      private bool _success;

      public bool Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      [Serializable]
      public struct Isset {
        public bool success;
      }

      public fooEx_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.Bool) {
                Success = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("fooEx_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          field.Name = "Success";
          field.Type = TType.Bool;
          field.ID = 0;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(Success);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("fooEx_result(");
        sb.Append("Success: ");
        sb.Append(Success);
        sb.Append(")");
        return sb.ToString();
      }

    }


    [Serializable]
    public partial class bar_args : TBase
    {

      public bar_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("bar_args");
        oprot.WriteStructBegin(struc);
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("bar_args(");
        sb.Append(")");
        return sb.ToString();
      }

    }


    [Serializable]
    public partial class bar_result : TBase
    {
      private bool _success;

      public bool Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      [Serializable]
      public struct Isset {
        public bool success;
      }

      public bar_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.Bool) {
                Success = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("bar_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          field.Name = "Success";
          field.Type = TType.Bool;
          field.ID = 0;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(Success);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("bar_result(");
        sb.Append("Success: ");
        sb.Append(Success);
        sb.Append(")");
        return sb.ToString();
      }

    }

  }
}
