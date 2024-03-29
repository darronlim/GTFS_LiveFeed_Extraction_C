﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Translink_LiveFeed_Service.transit_realtime;
using ProtoBuf;
using System.Net;

namespace Translink_LiveFeed_Service
{
    namespace transit_realtime
    {
        [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"FeedMessage")]
        public partial class FeedMessage : global::ProtoBuf.IExtensible
        {
            public FeedMessage() { }

            private transit_realtime.FeedHeader _header;
            [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
            public transit_realtime.FeedHeader header
            {
                get { return _header; }
                set { _header = value; }
            }
            private readonly global::System.Collections.Generic.List<transit_realtime.FeedEntity> _entity = new global::System.Collections.Generic.List<transit_realtime.FeedEntity>();
            [global::ProtoBuf.ProtoMember(2, Name = @"entity", DataFormat = global::ProtoBuf.DataFormat.Default)]
            public global::System.Collections.Generic.List<transit_realtime.FeedEntity> entity
            {
                get { return _entity; }
            }

            private global::ProtoBuf.IExtension extensionObject;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        }

        [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"FeedHeader")]
        public partial class FeedHeader : global::ProtoBuf.IExtensible
        {
            public FeedHeader() { }

            private string _gtfs_realtime_version;
            [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"gtfs_realtime_version", DataFormat = global::ProtoBuf.DataFormat.Default)]
            public string gtfs_realtime_version
            {
                get { return _gtfs_realtime_version; }
                set { _gtfs_realtime_version = value; }
            }

            private transit_realtime.FeedHeader.Incrementality _incrementality = transit_realtime.FeedHeader.Incrementality.FULL_DATASET;
            [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"incrementality", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(transit_realtime.FeedHeader.Incrementality.FULL_DATASET)]
            public transit_realtime.FeedHeader.Incrementality incrementality
            {
                get { return _incrementality; }
                set { _incrementality = value; }
            }

            private ulong _timestamp = default(ulong);
            [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"timestamp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(default(ulong))]
            public ulong timestamp
            {
                get { return _timestamp; }
                set { _timestamp = value; }
            }
            [global::ProtoBuf.ProtoContract(Name = @"Incrementality")]
            public enum Incrementality
            {

                [global::ProtoBuf.ProtoEnum(Name = @"FULL_DATASET", Value = 0)]
                FULL_DATASET = 0,

                [global::ProtoBuf.ProtoEnum(Name = @"DIFFERENTIAL", Value = 1)]
                DIFFERENTIAL = 1
            }

            private global::ProtoBuf.IExtension extensionObject;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        }

        [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"FeedEntity")]
        public partial class FeedEntity : global::ProtoBuf.IExtensible
        {
            public FeedEntity() { }

            private string _id;
            [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"id", DataFormat = global::ProtoBuf.DataFormat.Default)]
            public string id
            {
                get { return _id; }
                set { _id = value; }
            }

            private bool _is_deleted = (bool)false;
            [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"is_deleted", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue((bool)false)]
            public bool is_deleted
            {
                get { return _is_deleted; }
                set { _is_deleted = value; }
            }

            private transit_realtime.TripUpdate _trip_update = null;
            [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"trip_update", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue(null)]
            public transit_realtime.TripUpdate trip_update
            {
                get { return _trip_update; }
                set { _trip_update = value; }
            }

            private transit_realtime.VehiclePosition _vehicle = null;
            [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"vehicle", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue(null)]
            public transit_realtime.VehiclePosition vehicle
            {
                get { return _vehicle; }
                set { _vehicle = value; }
            }

            private transit_realtime.Alert _alert = null;
            [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"alert", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue(null)]
            public transit_realtime.Alert alert
            {
                get { return _alert; }
                set { _alert = value; }
            }
            private global::ProtoBuf.IExtension extensionObject;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        }

        [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"TripUpdate")]
        public partial class TripUpdate : global::ProtoBuf.IExtensible
        {
            public TripUpdate() { }

            private transit_realtime.TripDescriptor _trip;
            [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"trip", DataFormat = global::ProtoBuf.DataFormat.Default)]
            public transit_realtime.TripDescriptor trip
            {
                get { return _trip; }
                set { _trip = value; }
            }

            private transit_realtime.VehicleDescriptor _vehicle = null;
            [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"vehicle", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue(null)]
            public transit_realtime.VehicleDescriptor vehicle
            {
                get { return _vehicle; }
                set { _vehicle = value; }
            }
            private readonly global::System.Collections.Generic.List<transit_realtime.TripUpdate.StopTimeUpdate> _stop_time_update = new global::System.Collections.Generic.List<transit_realtime.TripUpdate.StopTimeUpdate>();
            [global::ProtoBuf.ProtoMember(2, Name = @"stop_time_update", DataFormat = global::ProtoBuf.DataFormat.Default)]
            public global::System.Collections.Generic.List<transit_realtime.TripUpdate.StopTimeUpdate> stop_time_update
            {
                get { return _stop_time_update; }
            }


            private ulong _timestamp = default(ulong);
            [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"timestamp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(default(ulong))]
            public ulong timestamp
            {
                get { return _timestamp; }
                set { _timestamp = value; }
            }

            private int _delay = default(int);
            [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"delay", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(default(int))]
            public int delay
            {
                get { return _delay; }
                set { _delay = value; }
            }
            [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"StopTimeEvent")]
            public partial class StopTimeEvent : global::ProtoBuf.IExtensible
            {
                public StopTimeEvent() { }


                private int _delay = default(int);
                [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"delay", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
                [global::System.ComponentModel.DefaultValue(default(int))]
                public int delay
                {
                    get { return _delay; }
                    set { _delay = value; }
                }

                private long _time = default(long);
                [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"time", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
                [global::System.ComponentModel.DefaultValue(default(long))]
                public long time
                {
                    get { return _time; }
                    set { _time = value; }
                }

                private int _uncertainty = default(int);
                [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"uncertainty", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
                [global::System.ComponentModel.DefaultValue(default(int))]
                public int uncertainty
                {
                    get { return _uncertainty; }
                    set { _uncertainty = value; }
                }
                private global::ProtoBuf.IExtension extensionObject;
                global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
                { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
            }

            [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"StopTimeUpdate")]
            public partial class StopTimeUpdate : global::ProtoBuf.IExtensible
            {
                public StopTimeUpdate() { }


                private uint _stop_sequence = default(uint);
                [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"stop_sequence", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
                [global::System.ComponentModel.DefaultValue(default(uint))]
                public uint stop_sequence
                {
                    get { return _stop_sequence; }
                    set { _stop_sequence = value; }
                }

                private string _stop_id = "";
                [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"stop_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
                [global::System.ComponentModel.DefaultValue("")]
                public string stop_id
                {
                    get { return _stop_id; }
                    set { _stop_id = value; }
                }

                private transit_realtime.TripUpdate.StopTimeEvent _arrival = null;
                [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"arrival", DataFormat = global::ProtoBuf.DataFormat.Default)]
                [global::System.ComponentModel.DefaultValue(null)]
                public transit_realtime.TripUpdate.StopTimeEvent arrival
                {
                    get { return _arrival; }
                    set { _arrival = value; }
                }

                private transit_realtime.TripUpdate.StopTimeEvent _departure = null;
                [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"departure", DataFormat = global::ProtoBuf.DataFormat.Default)]
                [global::System.ComponentModel.DefaultValue(null)]
                public transit_realtime.TripUpdate.StopTimeEvent departure
                {
                    get { return _departure; }
                    set { _departure = value; }
                }

                private transit_realtime.TripUpdate.StopTimeUpdate.ScheduleRelationship _schedule_relationship = transit_realtime.TripUpdate.StopTimeUpdate.ScheduleRelationship.SCHEDULED;
                [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"schedule_relationship", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
                [global::System.ComponentModel.DefaultValue(transit_realtime.TripUpdate.StopTimeUpdate.ScheduleRelationship.SCHEDULED)]
                public transit_realtime.TripUpdate.StopTimeUpdate.ScheduleRelationship schedule_relationship
                {
                    get { return _schedule_relationship; }
                    set { _schedule_relationship = value; }
                }
                [global::ProtoBuf.ProtoContract(Name = @"ScheduleRelationship")]
                public enum ScheduleRelationship
                {

                    [global::ProtoBuf.ProtoEnum(Name = @"SCHEDULED", Value = 0)]
                    SCHEDULED = 0,

                    [global::ProtoBuf.ProtoEnum(Name = @"SKIPPED", Value = 1)]
                    SKIPPED = 1,

                    [global::ProtoBuf.ProtoEnum(Name = @"NO_DATA", Value = 2)]
                    NO_DATA = 2,

                    [global::ProtoBuf.ProtoEnum(Name = @"ILLEGAL", Value = 5)]
                    ILLEGAL = 5
                }

                private global::ProtoBuf.IExtension extensionObject;
                global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
                { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
            }

            private global::ProtoBuf.IExtension extensionObject;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        }

        [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"VehiclePosition")]
        public partial class VehiclePosition : global::ProtoBuf.IExtensible
        {
            public VehiclePosition() { }


            private transit_realtime.TripDescriptor _trip = null;
            [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"trip", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue(null)]
            public transit_realtime.TripDescriptor trip
            {
                get { return _trip; }
                set { _trip = value; }
            }

            private transit_realtime.VehicleDescriptor _vehicle = null;
            [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name = @"vehicle", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue(null)]
            public transit_realtime.VehicleDescriptor vehicle
            {
                get { return _vehicle; }
                set { _vehicle = value; }
            }

            private transit_realtime.Position _position = null;
            [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"position", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue(null)]
            public transit_realtime.Position position
            {
                get { return _position; }
                set { _position = value; }
            }

            private uint _current_stop_sequence = default(uint);
            [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"current_stop_sequence", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(default(uint))]
            public uint current_stop_sequence
            {
                get { return _current_stop_sequence; }
                set { _current_stop_sequence = value; }
            }

            private string _stop_id = "";
            [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name = @"stop_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue("")]
            public string stop_id
            {
                get { return _stop_id; }
                set { _stop_id = value; }
            }

            private transit_realtime.VehiclePosition.VehicleStopStatus _current_status = transit_realtime.VehiclePosition.VehicleStopStatus.IN_TRANSIT_TO;
            [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"current_status", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(transit_realtime.VehiclePosition.VehicleStopStatus.IN_TRANSIT_TO)]
            public transit_realtime.VehiclePosition.VehicleStopStatus current_status
            {
                get { return _current_status; }
                set { _current_status = value; }
            }

            private ulong _timestamp = default(ulong);
            [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"timestamp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(default(ulong))]
            public ulong timestamp
            {
                get { return _timestamp; }
                set { _timestamp = value; }
            }

            private transit_realtime.VehiclePosition.CongestionLevel _congestion_level = transit_realtime.VehiclePosition.CongestionLevel.UNKNOWN_CONGESTION_LEVEL;
            [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name = @"congestion_level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(transit_realtime.VehiclePosition.CongestionLevel.UNKNOWN_CONGESTION_LEVEL)]
            public transit_realtime.VehiclePosition.CongestionLevel congestion_level
            {
                get { return _congestion_level; }
                set { _congestion_level = value; }
            }

            private transit_realtime.VehiclePosition.OccupancyStatus _occupancy_status = transit_realtime.VehiclePosition.OccupancyStatus.EMPTY;
            [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name = @"occupancy_status", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(transit_realtime.VehiclePosition.OccupancyStatus.EMPTY)]
            public transit_realtime.VehiclePosition.OccupancyStatus occupancy_status
            {
                get { return _occupancy_status; }
                set { _occupancy_status = value; }
            }
            [global::ProtoBuf.ProtoContract(Name = @"VehicleStopStatus")]
            public enum VehicleStopStatus
            {

                [global::ProtoBuf.ProtoEnum(Name = @"INCOMING_AT", Value = 0)]
                INCOMING_AT = 0,

                [global::ProtoBuf.ProtoEnum(Name = @"STOPPED_AT", Value = 1)]
                STOPPED_AT = 1,

                [global::ProtoBuf.ProtoEnum(Name = @"IN_TRANSIT_TO", Value = 2)]
                IN_TRANSIT_TO = 2
            }

            [global::ProtoBuf.ProtoContract(Name = @"CongestionLevel")]
            public enum CongestionLevel
            {

                [global::ProtoBuf.ProtoEnum(Name = @"UNKNOWN_CONGESTION_LEVEL", Value = 0)]
                UNKNOWN_CONGESTION_LEVEL = 0,

                [global::ProtoBuf.ProtoEnum(Name = @"RUNNING_SMOOTHLY", Value = 1)]
                RUNNING_SMOOTHLY = 1,

                [global::ProtoBuf.ProtoEnum(Name = @"STOP_AND_GO", Value = 2)]
                STOP_AND_GO = 2,

                [global::ProtoBuf.ProtoEnum(Name = @"CONGESTION", Value = 3)]
                CONGESTION = 3,

                [global::ProtoBuf.ProtoEnum(Name = @"SEVERE_CONGESTION", Value = 4)]
                SEVERE_CONGESTION = 4
            }

            [global::ProtoBuf.ProtoContract(Name = @"OccupancyStatus")]
            public enum OccupancyStatus
            {

                [global::ProtoBuf.ProtoEnum(Name = @"EMPTY", Value = 0)]
                EMPTY = 0,

                [global::ProtoBuf.ProtoEnum(Name = @"MANY_SEATS_AVAILABLE", Value = 1)]
                MANY_SEATS_AVAILABLE = 1,

                [global::ProtoBuf.ProtoEnum(Name = @"FEW_SEATS_AVAILABLE", Value = 2)]
                FEW_SEATS_AVAILABLE = 2,

                [global::ProtoBuf.ProtoEnum(Name = @"STANDING_ROOM_ONLY", Value = 3)]
                STANDING_ROOM_ONLY = 3,

                [global::ProtoBuf.ProtoEnum(Name = @"CRUSHED_STANDING_ROOM_ONLY", Value = 4)]
                CRUSHED_STANDING_ROOM_ONLY = 4,

                [global::ProtoBuf.ProtoEnum(Name = @"FULL", Value = 5)]
                FULL = 5,

                [global::ProtoBuf.ProtoEnum(Name = @"NOT_ACCEPTING_PASSENGERS", Value = 6)]
                NOT_ACCEPTING_PASSENGERS = 6
            }

            private global::ProtoBuf.IExtension extensionObject;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        }

        [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Alert")]
        public partial class Alert : global::ProtoBuf.IExtensible
        {
            public Alert() { }

            private readonly global::System.Collections.Generic.List<transit_realtime.TimeRange> _active_period = new global::System.Collections.Generic.List<transit_realtime.TimeRange>();
            [global::ProtoBuf.ProtoMember(1, Name = @"active_period", DataFormat = global::ProtoBuf.DataFormat.Default)]
            public global::System.Collections.Generic.List<transit_realtime.TimeRange> active_period
            {
                get { return _active_period; }
            }

            private readonly global::System.Collections.Generic.List<transit_realtime.EntitySelector> _informed_entity = new global::System.Collections.Generic.List<transit_realtime.EntitySelector>();
            [global::ProtoBuf.ProtoMember(5, Name = @"informed_entity", DataFormat = global::ProtoBuf.DataFormat.Default)]
            public global::System.Collections.Generic.List<transit_realtime.EntitySelector> informed_entity
            {
                get { return _informed_entity; }
            }


            private transit_realtime.Alert.Cause _cause = transit_realtime.Alert.Cause.UNKNOWN_CAUSE;
            [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name = @"cause", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(transit_realtime.Alert.Cause.UNKNOWN_CAUSE)]
            public transit_realtime.Alert.Cause cause
            {
                get { return _cause; }
                set { _cause = value; }
            }

            private transit_realtime.Alert.Effect _effect = transit_realtime.Alert.Effect.UNKNOWN_EFFECT;
            [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name = @"effect", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(transit_realtime.Alert.Effect.UNKNOWN_EFFECT)]
            public transit_realtime.Alert.Effect effect
            {
                get { return _effect; }
                set { _effect = value; }
            }

            private transit_realtime.TranslatedString _url = null;
            [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name = @"url", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue(null)]
            public transit_realtime.TranslatedString url
            {
                get { return _url; }
                set { _url = value; }
            }

            private transit_realtime.TranslatedString _header_text = null;
            [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name = @"header_text", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue(null)]
            public transit_realtime.TranslatedString header_text
            {
                get { return _header_text; }
                set { _header_text = value; }
            }

            private transit_realtime.TranslatedString _description_text = null;
            [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name = @"description_text", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue(null)]
            public transit_realtime.TranslatedString description_text
            {
                get { return _description_text; }
                set { _description_text = value; }
            }
            [global::ProtoBuf.ProtoContract(Name = @"Cause")]
            public enum Cause
            {

                [global::ProtoBuf.ProtoEnum(Name = @"UNKNOWN_CAUSE", Value = 1)]
                UNKNOWN_CAUSE = 1,

                [global::ProtoBuf.ProtoEnum(Name = @"OTHER_CAUSE", Value = 2)]
                OTHER_CAUSE = 2,

                [global::ProtoBuf.ProtoEnum(Name = @"TECHNICAL_PROBLEM", Value = 3)]
                TECHNICAL_PROBLEM = 3,

                [global::ProtoBuf.ProtoEnum(Name = @"STRIKE", Value = 4)]
                STRIKE = 4,

                [global::ProtoBuf.ProtoEnum(Name = @"DEMONSTRATION", Value = 5)]
                DEMONSTRATION = 5,

                [global::ProtoBuf.ProtoEnum(Name = @"ACCIDENT", Value = 6)]
                ACCIDENT = 6,

                [global::ProtoBuf.ProtoEnum(Name = @"HOLIDAY", Value = 7)]
                HOLIDAY = 7,

                [global::ProtoBuf.ProtoEnum(Name = @"WEATHER", Value = 8)]
                WEATHER = 8,

                [global::ProtoBuf.ProtoEnum(Name = @"MAINTENANCE", Value = 9)]
                MAINTENANCE = 9,

                [global::ProtoBuf.ProtoEnum(Name = @"CONSTRUCTION", Value = 10)]
                CONSTRUCTION = 10,

                [global::ProtoBuf.ProtoEnum(Name = @"POLICE_ACTIVITY", Value = 11)]
                POLICE_ACTIVITY = 11,

                [global::ProtoBuf.ProtoEnum(Name = @"MEDICAL_EMERGENCY", Value = 12)]
                MEDICAL_EMERGENCY = 12
            }

            [global::ProtoBuf.ProtoContract(Name = @"Effect")]
            public enum Effect
            {

                [global::ProtoBuf.ProtoEnum(Name = @"NO_SERVICE", Value = 1)]
                NO_SERVICE = 1,

                [global::ProtoBuf.ProtoEnum(Name = @"REDUCED_SERVICE", Value = 2)]
                REDUCED_SERVICE = 2,

                [global::ProtoBuf.ProtoEnum(Name = @"SIGNIFICANT_DELAYS", Value = 3)]
                SIGNIFICANT_DELAYS = 3,

                [global::ProtoBuf.ProtoEnum(Name = @"DETOUR", Value = 4)]
                DETOUR = 4,

                [global::ProtoBuf.ProtoEnum(Name = @"ADDITIONAL_SERVICE", Value = 5)]
                ADDITIONAL_SERVICE = 5,

                [global::ProtoBuf.ProtoEnum(Name = @"MODIFIED_SERVICE", Value = 6)]
                MODIFIED_SERVICE = 6,

                [global::ProtoBuf.ProtoEnum(Name = @"OTHER_EFFECT", Value = 7)]
                OTHER_EFFECT = 7,

                [global::ProtoBuf.ProtoEnum(Name = @"UNKNOWN_EFFECT", Value = 8)]
                UNKNOWN_EFFECT = 8,

                [global::ProtoBuf.ProtoEnum(Name = @"STOP_MOVED", Value = 9)]
                STOP_MOVED = 9
            }

            private global::ProtoBuf.IExtension extensionObject;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        }

        [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"TimeRange")]
        public partial class TimeRange : global::ProtoBuf.IExtensible
        {
            public TimeRange() { }


            private ulong _start = default(ulong);
            [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"start", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(default(ulong))]
            public ulong start
            {
                get { return _start; }
                set { _start = value; }
            }

            private ulong _end = default(ulong);
            [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"end", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(default(ulong))]
            public ulong end
            {
                get { return _end; }
                set { _end = value; }
            }
            private global::ProtoBuf.IExtension extensionObject;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        }

        [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Position")]
        public partial class Position : global::ProtoBuf.IExtensible
        {
            public Position() { }

            private float _latitude;
            [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"latitude", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
            public float latitude
            {
                get { return _latitude; }
                set { _latitude = value; }
            }
            private float _longitude;
            [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"longitude", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
            public float longitude
            {
                get { return _longitude; }
                set { _longitude = value; }
            }

            private float _bearing = default(float);
            [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"bearing", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
            [global::System.ComponentModel.DefaultValue(default(float))]
            public float bearing
            {
                get { return _bearing; }
                set { _bearing = value; }
            }

            private double _odometer = default(double);
            [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"odometer", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(default(double))]
            public double odometer
            {
                get { return _odometer; }
                set { _odometer = value; }
            }

            private float _speed = default(float);
            [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"speed", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
            [global::System.ComponentModel.DefaultValue(default(float))]
            public float speed
            {
                get { return _speed; }
                set { _speed = value; }
            }
            private global::ProtoBuf.IExtension extensionObject;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        }

        [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"TripDescriptor")]
        public partial class TripDescriptor : global::ProtoBuf.IExtensible
        {
            public TripDescriptor() { }


            private string _trip_id = "";
            [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"trip_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue("")]
            public string trip_id
            {
                get { return _trip_id; }
                set { _trip_id = value; }
            }

            private string _route_id = "";
            [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"route_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue("")]
            public string route_id
            {
                get { return _route_id; }
                set { _route_id = value; }
            }

            private uint _direction_id = default(uint);
            [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name = @"direction_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(default(uint))]
            public uint direction_id
            {
                get { return _direction_id; }
                set { _direction_id = value; }
            }

            private string _start_time = "";
            [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"start_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue("")]
            public string start_time
            {
                get { return _start_time; }
                set { _start_time = value; }
            }

            private string _start_date = "";
            [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"start_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue("")]
            public string start_date
            {
                get { return _start_date; }
                set { _start_date = value; }
            }

            private transit_realtime.TripDescriptor.ScheduleRelationship _schedule_relationship = transit_realtime.TripDescriptor.ScheduleRelationship.SCHEDULED;
            [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"schedule_relationship", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(transit_realtime.TripDescriptor.ScheduleRelationship.SCHEDULED)]
            public transit_realtime.TripDescriptor.ScheduleRelationship schedule_relationship
            {
                get { return _schedule_relationship; }
                set { _schedule_relationship = value; }
            }
            [global::ProtoBuf.ProtoContract(Name = @"ScheduleRelationship")]
            public enum ScheduleRelationship
            {

                [global::ProtoBuf.ProtoEnum(Name = @"SCHEDULED", Value = 0)]
                SCHEDULED = 0,

                [global::ProtoBuf.ProtoEnum(Name = @"ADDED", Value = 1)]
                ADDED = 1,

                [global::ProtoBuf.ProtoEnum(Name = @"UNSCHEDULED", Value = 2)]
                UNSCHEDULED = 2,

                [global::ProtoBuf.ProtoEnum(Name = @"CANCELED", Value = 3)]
                CANCELED = 3,

                [global::ProtoBuf.ProtoEnum(Name = @"ILLEGAL", Value = 5)]
                ILLEGAL = 5
            }

            private global::ProtoBuf.IExtension extensionObject;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        }

        [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"VehicleDescriptor")]
        public partial class VehicleDescriptor : global::ProtoBuf.IExtensible
        {
            public VehicleDescriptor() { }


            private string _id = "";
            [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"id", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue("")]
            public string id
            {
                get { return _id; }
                set { _id = value; }
            }

            private string _label = "";
            [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"label", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue("")]
            public string label
            {
                get { return _label; }
                set { _label = value; }
            }

            private string _license_plate = "";
            [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"license_plate", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue("")]
            public string license_plate
            {
                get { return _license_plate; }
                set { _license_plate = value; }
            }
            private global::ProtoBuf.IExtension extensionObject;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        }

        [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"EntitySelector")]
        public partial class EntitySelector : global::ProtoBuf.IExtensible
        {
            public EntitySelector() { }


            private string _agency_id = "";
            [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"agency_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue("")]
            public string agency_id
            {
                get { return _agency_id; }
                set { _agency_id = value; }
            }

            private string _route_id = "";
            [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"route_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue("")]
            public string route_id
            {
                get { return _route_id; }
                set { _route_id = value; }
            }

            private int _route_type = default(int);
            [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"route_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
            [global::System.ComponentModel.DefaultValue(default(int))]
            public int route_type
            {
                get { return _route_type; }
                set { _route_type = value; }
            }

            private transit_realtime.TripDescriptor _trip = null;
            [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"trip", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue(null)]
            public transit_realtime.TripDescriptor trip
            {
                get { return _trip; }
                set { _trip = value; }
            }

            private string _stop_id = "";
            [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"stop_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
            [global::System.ComponentModel.DefaultValue("")]
            public string stop_id
            {
                get { return _stop_id; }
                set { _stop_id = value; }
            }
            private global::ProtoBuf.IExtension extensionObject;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        }

        [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"TranslatedString")]
        public partial class TranslatedString : global::ProtoBuf.IExtensible
        {
            public TranslatedString() { }

            private readonly global::System.Collections.Generic.List<transit_realtime.TranslatedString.Translation> _translation = new global::System.Collections.Generic.List<transit_realtime.TranslatedString.Translation>();
            [global::ProtoBuf.ProtoMember(1, Name = @"translation", DataFormat = global::ProtoBuf.DataFormat.Default)]
            public global::System.Collections.Generic.List<transit_realtime.TranslatedString.Translation> translation
            {
                get { return _translation; }
            }

            [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Translation")]
            public partial class Translation : global::ProtoBuf.IExtensible
            {
                public Translation() { }

                private string _text;
                [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"text", DataFormat = global::ProtoBuf.DataFormat.Default)]
                public string text
                {
                    get { return _text; }
                    set { _text = value; }
                }

                private string _language = "";
                [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"language", DataFormat = global::ProtoBuf.DataFormat.Default)]
                [global::System.ComponentModel.DefaultValue("")]
                public string language
                {
                    get { return _language; }
                    set { _language = value; }
                }
                private global::ProtoBuf.IExtension extensionObject;
                global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
                { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
            }

            private global::ProtoBuf.IExtension extensionObject;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        }

    }

    public partial class Translink_Vehicle_Data : ServiceBase
    {
        private int timerSec;
        private string logFilePath;

        public Translink_Vehicle_Data()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            logFilePath = AppDomain.CurrentDomain.BaseDirectory + "Translink_Vehicle_Data.log";
            timerSec = Convert.ToInt32(ConfigurationManager.AppSettings["Timer"]);
            timer1.Interval = timerSec;

            Translink_Main();
            timer1.Start();
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
        }

        public void Translink_Main()
        {
            string _connstring = ConfigurationManager.AppSettings["ConnectionString"];

            SQL test = new SQL();
            string errormsg = "";
            DataSet dsbl = new DataSet();
            DataRow dsrow = null;

            WebRequest req = HttpWebRequest.Create("https://gtfsrt.api.translink.com.au/Feed/SEQ");
            transit_realtime.FeedMessage feed = Serializer.Deserialize<transit_realtime.FeedMessage>(req.GetResponse().GetResponseStream());

            if (feed.entity.Count > 0)
            {
                test.FetchGTFS(_connstring, ref dsbl, ref errormsg);

                foreach (transit_realtime.FeedEntity entity in feed.entity)
                {
                    dsrow = dsbl.Tables[0].NewRow();
                    if (entity.vehicle != null)
                    {
                        //Vehicle general data
                        dsrow["VehicleID"] = entity.vehicle.vehicle.id.ToString();
                        dsrow["VehicleLabel"] = entity.vehicle.vehicle.label.ToString();
                        dsrow["LicensePlate"] = entity.vehicle.vehicle.license_plate.ToString();
                        dsrow["CongestionLevel"] = entity.vehicle.congestion_level.ToString();
                        dsrow["CurrentStatus"] = entity.vehicle.current_status.ToString();
                        dsrow["CurrentStopStatus"] = entity.vehicle.current_stop_sequence.ToString();
                        dsrow["CurrentStopSequence"] = entity.vehicle.current_stop_sequence.ToString();
                        dsrow["OccupancyStatus"] = entity.vehicle.occupancy_status.ToString();
                        dsrow["StopID"] = entity.vehicle.stop_id.ToString();
                        dsrow["VehicleTimestamp"] = entity.vehicle.timestamp.ToString();

                        //Vehicle Trip data
                        dsrow["VehicleDirectionID"] = entity.vehicle.trip.direction_id.ToString();
                        dsrow["VehicleRouteID"] = entity.vehicle.trip.route_id.ToString();
                        dsrow["VehicleScheduleRelationship"] = entity.vehicle.trip.schedule_relationship.ToString();
                        dsrow["VehicleStartDate"] = entity.vehicle.trip.start_date.ToString();
                        dsrow["VehicleStartTime"] = entity.vehicle.trip.start_time.ToString();
                        dsrow["VehicleTripID"] = entity.vehicle.trip.trip_id.ToString();

                        //Vehicle Position data
                        dsrow["VehicleBearing"] = entity.vehicle.position.bearing.ToString();
                        dsrow["VehicleLatitude"] = entity.vehicle.position.latitude.ToString();
                        dsrow["VehicleLongitude"] = entity.vehicle.position.longitude.ToString();
                        dsrow["VehicleOdometer"] = entity.vehicle.position.odometer.ToString();
                        dsrow["VehicleSpeed"] = entity.vehicle.position.speed.ToString();

                        dsbl.Tables[0].Rows.Add(dsrow);

                        //13.05.2019 Added ID
                        dsrow["ID"] = entity.id.ToString();

                    }

                    //13.05.2019 Added fetching Trip update, insert to TripUpdate datatable
                    //I would like to a these fields to a new table called translink_tripupdate
                    if (entity.trip_update != null)
                    {
                        dsrow = dsbl.Tables["TripUpdate"].NewRow();
                        dsrow["TripID"] = entity.trip_update.trip.trip_id.ToString();
                        dsrow["DirectionID"] = entity.trip_update.trip.direction_id.ToString();
                        dsrow["RouteID"] = entity.trip_update.trip.route_id.ToString();
                        dsrow["ScheduleRelationship"] = entity.trip_update.trip.schedule_relationship.ToString();
                        dsrow["StartDate"] = entity.trip_update.trip.start_date.ToString();
                        dsrow["StartTime"] = entity.trip_update.trip.start_time.ToString();
                        dsrow["StopTimeUpdate"] = entity.trip_update.stop_time_update.ToString();
                        dsrow["Delay"] = entity.trip_update.delay.ToString();
                        dsrow["Timestamp"] = entity.trip_update.timestamp.ToString();

                        //13.05.2019 Added ID
                        dsrow["ID"] = entity.id.ToString();

                        dsbl.Tables["TripUpdate"].Rows.Add(dsrow);
                    }
                }

                if (dsbl.Tables[0].Rows.Count > 0)
                {
                    test.InsertGTFS(_connstring, dsbl, ref errormsg);
                }
            }

            test.FetchAll(_connstring, ref dsbl, ref errormsg);
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Translink_Main();
        }
    }
}
