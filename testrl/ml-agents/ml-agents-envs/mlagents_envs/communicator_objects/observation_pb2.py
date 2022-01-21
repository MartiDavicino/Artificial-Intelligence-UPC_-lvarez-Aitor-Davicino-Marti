# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: mlagents_envs/communicator_objects/observation.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf.internal import enum_type_wrapper
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
from google.protobuf import descriptor_pb2
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='mlagents_envs/communicator_objects/observation.proto',
  package='communicator_objects',
  syntax='proto3',
  serialized_pb=_b('\n4mlagents_envs/communicator_objects/observation.proto\x12\x14\x63ommunicator_objects\"\x8f\x03\n\x10ObservationProto\x12\r\n\x05shape\x18\x01 \x03(\x05\x12\x44\n\x10\x63ompression_type\x18\x02 \x01(\x0e\x32*.communicator_objects.CompressionTypeProto\x12\x19\n\x0f\x63ompressed_data\x18\x03 \x01(\x0cH\x00\x12\x46\n\nfloat_data\x18\x04 \x01(\x0b\x32\x30.communicator_objects.ObservationProto.FloatDataH\x00\x12\"\n\x1a\x63ompressed_channel_mapping\x18\x05 \x03(\x05\x12\x1c\n\x14\x64imension_properties\x18\x06 \x03(\x05\x12\x44\n\x10observation_type\x18\x07 \x01(\x0e\x32*.communicator_objects.ObservationTypeProto\x12\x0c\n\x04name\x18\x08 \x01(\t\x1a\x19\n\tFloatData\x12\x0c\n\x04\x64\x61ta\x18\x01 \x03(\x02\x42\x12\n\x10observation_data*)\n\x14\x43ompressionTypeProto\x12\x08\n\x04NONE\x10\x00\x12\x07\n\x03PNG\x10\x01*@\n\x14ObservationTypeProto\x12\x0b\n\x07\x44\x45\x46\x41ULT\x10\x00\x12\x0f\n\x0bGOAL_SIGNAL\x10\x01\"\x04\x08\x02\x10\x02\"\x04\x08\x03\x10\x03\x42%\xaa\x02\"Unity.MLAgents.CommunicatorObjectsb\x06proto3')
)

_COMPRESSIONTYPEPROTO = _descriptor.EnumDescriptor(
  name='CompressionTypeProto',
  full_name='communicator_objects.CompressionTypeProto',
  filename=None,
  file=DESCRIPTOR,
  values=[
    _descriptor.EnumValueDescriptor(
      name='NONE', index=0, number=0,
      options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='PNG', index=1, number=1,
      options=None,
      type=None),
  ],
  containing_type=None,
  options=None,
  serialized_start=480,
  serialized_end=521,
)
_sym_db.RegisterEnumDescriptor(_COMPRESSIONTYPEPROTO)

CompressionTypeProto = enum_type_wrapper.EnumTypeWrapper(_COMPRESSIONTYPEPROTO)
_OBSERVATIONTYPEPROTO = _descriptor.EnumDescriptor(
  name='ObservationTypeProto',
  full_name='communicator_objects.ObservationTypeProto',
  filename=None,
  file=DESCRIPTOR,
  values=[
    _descriptor.EnumValueDescriptor(
      name='DEFAULT', index=0, number=0,
      options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='GOAL_SIGNAL', index=1, number=1,
      options=None,
      type=None),
  ],
  containing_type=None,
  options=None,
  serialized_start=523,
  serialized_end=587,
)
_sym_db.RegisterEnumDescriptor(_OBSERVATIONTYPEPROTO)

ObservationTypeProto = enum_type_wrapper.EnumTypeWrapper(_OBSERVATIONTYPEPROTO)
NONE = 0
PNG = 1
DEFAULT = 0
GOAL_SIGNAL = 1



_OBSERVATIONPROTO_FLOATDATA = _descriptor.Descriptor(
  name='FloatData',
  full_name='communicator_objects.ObservationProto.FloatData',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='data', full_name='communicator_objects.ObservationProto.FloatData.data', index=0,
      number=1, type=2, cpp_type=6, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=433,
  serialized_end=458,
)

_OBSERVATIONPROTO = _descriptor.Descriptor(
  name='ObservationProto',
  full_name='communicator_objects.ObservationProto',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='shape', full_name='communicator_objects.ObservationProto.shape', index=0,
      number=1, type=5, cpp_type=1, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='compression_type', full_name='communicator_objects.ObservationProto.compression_type', index=1,
      number=2, type=14, cpp_type=8, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='compressed_data', full_name='communicator_objects.ObservationProto.compressed_data', index=2,
      number=3, type=12, cpp_type=9, label=1,
      has_default_value=False, default_value=_b(""),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='float_data', full_name='communicator_objects.ObservationProto.float_data', index=3,
      number=4, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='compressed_channel_mapping', full_name='communicator_objects.ObservationProto.compressed_channel_mapping', index=4,
      number=5, type=5, cpp_type=1, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='dimension_properties', full_name='communicator_objects.ObservationProto.dimension_properties', index=5,
      number=6, type=5, cpp_type=1, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='observation_type', full_name='communicator_objects.ObservationProto.observation_type', index=6,
      number=7, type=14, cpp_type=8, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name', full_name='communicator_objects.ObservationProto.name', index=7,
      number=8, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[_OBSERVATIONPROTO_FLOATDATA, ],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
    _descriptor.OneofDescriptor(
      name='observation_data', full_name='communicator_objects.ObservationProto.observation_data',
      index=0, containing_type=None, fields=[]),
  ],
  serialized_start=79,
  serialized_end=478,
)

_OBSERVATIONPROTO_FLOATDATA.containing_type = _OBSERVATIONPROTO
_OBSERVATIONPROTO.fields_by_name['compression_type'].enum_type = _COMPRESSIONTYPEPROTO
_OBSERVATIONPROTO.fields_by_name['float_data'].message_type = _OBSERVATIONPROTO_FLOATDATA
_OBSERVATIONPROTO.fields_by_name['observation_type'].enum_type = _OBSERVATIONTYPEPROTO
_OBSERVATIONPROTO.oneofs_by_name['observation_data'].fields.append(
  _OBSERVATIONPROTO.fields_by_name['compressed_data'])
_OBSERVATIONPROTO.fields_by_name['compressed_data'].containing_oneof = _OBSERVATIONPROTO.oneofs_by_name['observation_data']
_OBSERVATIONPROTO.oneofs_by_name['observation_data'].fields.append(
  _OBSERVATIONPROTO.fields_by_name['float_data'])
_OBSERVATIONPROTO.fields_by_name['float_data'].containing_oneof = _OBSERVATIONPROTO.oneofs_by_name['observation_data']
DESCRIPTOR.message_types_by_name['ObservationProto'] = _OBSERVATIONPROTO
DESCRIPTOR.enum_types_by_name['CompressionTypeProto'] = _COMPRESSIONTYPEPROTO
DESCRIPTOR.enum_types_by_name['ObservationTypeProto'] = _OBSERVATIONTYPEPROTO
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

ObservationProto = _reflection.GeneratedProtocolMessageType('ObservationProto', (_message.Message,), dict(

  FloatData = _reflection.GeneratedProtocolMessageType('FloatData', (_message.Message,), dict(
    DESCRIPTOR = _OBSERVATIONPROTO_FLOATDATA,
    __module__ = 'mlagents_envs.communicator_objects.observation_pb2'
    # @@protoc_insertion_point(class_scope:communicator_objects.ObservationProto.FloatData)
    ))
  ,
  DESCRIPTOR = _OBSERVATIONPROTO,
  __module__ = 'mlagents_envs.communicator_objects.observation_pb2'
  # @@protoc_insertion_point(class_scope:communicator_objects.ObservationProto)
  ))
_sym_db.RegisterMessage(ObservationProto)
_sym_db.RegisterMessage(ObservationProto.FloatData)


DESCRIPTOR.has_options = True
DESCRIPTOR._options = _descriptor._ParseOptions(descriptor_pb2.FileOptions(), _b('\252\002\"Unity.MLAgents.CommunicatorObjects'))
# @@protoc_insertion_point(module_scope)
