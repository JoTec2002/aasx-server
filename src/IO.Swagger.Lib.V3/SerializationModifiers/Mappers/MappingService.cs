﻿using DataTransferObjects;
using DataTransferObjects.MetadataDTOs;
using DataTransferObjects.ValueDTOs;
using IO.Swagger.Lib.V3.SerializationModifiers.Mappers.MetadataMappers;
using IO.Swagger.Lib.V3.SerializationModifiers.Mappers.ValueMappers;
using System;
using System.Collections.Generic;

namespace IO.Swagger.Lib.V3.SerializationModifiers.Mappers
{
    public class MappingService : IMappingService
    {
        public IDTO Map(IClass source, string mappingResolverKey)
        {
            if (mappingResolverKey == null)
            {
                throw new Exception($"Could not resolve serializer modifier mapper.");
            }

            //TODO (jtikekar, 0000-00-00): jtikekar Refactor
            if (mappingResolverKey.Equals("metadata", StringComparison.OrdinalIgnoreCase))
            {
                return ResponseMetadataMapper.Map(source);
            }
            else if (mappingResolverKey.Equals("value", StringComparison.OrdinalIgnoreCase))
            {
                return ResponseValueMapper.Map(source);
            }
            else
            {
                throw new Exception($"Invalid modifier mapping resolved key");
            }
        }

        public List<IDTO> Map(List<IClass> sourceList, string mappingResolverKey)
        {
            if (mappingResolverKey == null)
            {
                throw new Exception($"Could not resolve serializer modifier mapper.");
            }

            //TODO (jtikekar, 0000-00-00): jtikekar Refactor
            if (mappingResolverKey.Equals("metadata", StringComparison.OrdinalIgnoreCase))
            {
                var output = new List<IDTO>();

                foreach (var source in sourceList)
                {
                    var dto = ResponseMetadataMapper.Map(source);
                    output.Add(dto);
                }

                return output;
            }
            else if (mappingResolverKey.Equals("value", StringComparison.OrdinalIgnoreCase))
            {
                var output = new List<IDTO>();

                foreach (var source in sourceList)
                {
                    var dto = ResponseValueMapper.Map(source);
                    output.Add(dto);
                }

                return output;
            }
            else
            {
                throw new Exception($"Invalid modifier mapping resolved key");
            }
        }

        public IClass Map(IDTO dto, string mappingResolverKey)
        {
            if (mappingResolverKey == null)
            {
                throw new Exception($"Could not resolve serializer modifier mapper.");
            }

            //TODO (jtikekar, 0000-00-00): jtikekar Refactor
            if (mappingResolverKey.Equals("metadata", StringComparison.OrdinalIgnoreCase) && dto is IMetadataDTO metadataDTO)
            {
                return RequestMetadataMapper.Map(metadataDTO);
            }
            else if (mappingResolverKey.Equals("value", StringComparison.OrdinalIgnoreCase) && dto is IValueDTO valueDTO)
            {
                return RequestValueMapper.Map(valueDTO);
            }
            else
            {
                throw new Exception($"Invalid modifier mapping resolved key");
            }
        }
    }
}
