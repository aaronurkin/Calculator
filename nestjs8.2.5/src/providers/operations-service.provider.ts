import { Provider } from '@nestjs/common';
import { ServiceToken } from '@services/application/service-token';
import { IOperationsService } from '@services/application/operations.service';
import { OperationsService } from '@infrastructure/application/operations.service';

export const OperationsServiceProvider: Provider<IOperationsService> = {
  provide: ServiceToken.operationService,
  useClass: OperationsService,
};
