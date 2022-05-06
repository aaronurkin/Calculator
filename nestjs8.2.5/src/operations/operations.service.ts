import { ModuleRef } from '@nestjs/core';
import { Injectable } from '@nestjs/common';
import { IOperation } from './operation.interface';
import { OperationRequestDto } from '../operations/dto/operation-request.dto';
import { OperationResponseDto } from '../operations/dto/operation-response.dto';
import { IOperationResponseResolver } from './operation-response-resolver.interface';

@Injectable()
export class OperationsService {
  constructor(private moduleRef: ModuleRef) {}

  public handle(requestDto: OperationRequestDto): OperationResponseDto {
    const operation = this.moduleRef.get<IOperation>(
      `OPERATION${requestDto.operation}`,
    );

    const operationResult = operation.produce(requestDto);
    const operationResponseResolver =
      this.moduleRef.get<IOperationResponseResolver>(
        `RESPONSE${requestDto.responseType || ''}`,
      );

    return operationResponseResolver.resolve(operationResult);
  }
}
