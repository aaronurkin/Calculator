import { Provider } from '@nestjs/common';
import { IOperation } from '@services/application/operation';
import { DivisionOperation } from '@infrastructure/application/operations/division.operation';

export const DivisionOperationProvider: Provider<IOperation> = {
  provide: 'OPERATION/',
  useClass: DivisionOperation,
};
