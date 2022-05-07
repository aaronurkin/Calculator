import { Module } from '@nestjs/common';
import { OperationsService } from './operations.service';
import { OperationsController } from './operations.controller';
import { AdditionOperationProvider } from './providers/addition-operation.provider';
import { DivisionOperationProvider } from './providers/division-operation.provider';
import { SubtractionOperationProvider } from './providers/subtraction-operation.provider';
import { MultiplicationOperationProvider } from './providers/multiplication-operation.provider';
import { DefaultOperationResponseResolverProvider } from './providers/default-operation-response-resolver.provider';

@Module({
  controllers: [OperationsController],
  providers: [
    OperationsService,
    AdditionOperationProvider,
    DivisionOperationProvider,
    SubtractionOperationProvider,
    MultiplicationOperationProvider,
    DefaultOperationResponseResolverProvider,
  ],
})
export class OperationsModule {}
