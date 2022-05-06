import { Provider } from '@nestjs/common';
import { IOperation } from '../operation.interface';
import { DivisionOperation } from '../implementations/division.operation';

export const DivisionOperationProvider: Provider<IOperation> = {
  provide: 'OPERATION/',
  useClass: DivisionOperation,
};
