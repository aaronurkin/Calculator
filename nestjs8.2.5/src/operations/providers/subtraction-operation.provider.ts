import { Provider } from '@nestjs/common';
import { IOperation } from '../operation.interface';
import { SubtractionOperation } from '../implementations/subtraction.operation';

export const SubtractionOperationProvider: Provider<IOperation> = {
  provide: 'OPERATION-',
  useClass: SubtractionOperation,
};
