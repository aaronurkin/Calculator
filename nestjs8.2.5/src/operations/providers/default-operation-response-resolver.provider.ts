import { Provider } from '@nestjs/common';
import { IOperationResponseResolver } from '../operation-response-resolver.interface';
import { DefaultOperationResponseResolver } from '../implementations/default-operation-response.resolver';

export const DefaultOperationResponseResolverProvider: Provider<IOperationResponseResolver> =
  {
    provide: 'RESPONSE',
    useClass: DefaultOperationResponseResolver,
  };
