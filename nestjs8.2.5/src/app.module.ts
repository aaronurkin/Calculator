import { Module } from '@nestjs/common';
import { OperationsController } from '@controllers/operations.controller';
import { OperationsServiceProvider } from '@providers/operations-service.provider';
import { AdditionOperationProvider } from '@providers/addition-operation.provider';
import { DivisionOperationProvider } from '@providers/division-operation.provider';
import { ApplicationInfrastructureModule } from '@infrastructure/application/module';
import { SubtractionOperationProvider } from '@providers/subtraction-operation.provider';
import { MultiplicationOperationProvider } from '@providers/multiplication-operation.provider';
import { OperationResponseResolverProvider } from '@providers/operation-response-resolver.provider';

@Module({
  imports: [
    ApplicationInfrastructureModule,
  ],
  controllers: [
    OperationsController,
  ],
  providers: [
    OperationsServiceProvider,
    AdditionOperationProvider,
    DivisionOperationProvider,
    SubtractionOperationProvider,
    MultiplicationOperationProvider,
    OperationResponseResolverProvider,
  ],
})
export class AppModule {}
