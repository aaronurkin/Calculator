import { Provider } from '@nestjs/common';
import { ServiceToken } from '@services/application/service-token';
import { IOperationResponseResolver } from '@services/application/operation-response-resolver';
import { DefaultOperationResponseResolver } from '@infrastructure/application/default-operation-response.resolver';

export const OperationResponseResolverProvider: Provider<IOperationResponseResolver> =
  {
    provide: ServiceToken.operationResponseResolver,
    useClass: DefaultOperationResponseResolver,
  };
