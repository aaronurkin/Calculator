import { Post, Controller, Body, Inject } from '@nestjs/common';
import { ServiceToken } from '@services/application/service-token';
import { IOperationsService } from '@services/application/operations.service';
import { OperationRequestDto, OperationResponseDto } from '@services/application/dto';

@Controller('operations')
export class OperationsController {
  constructor(@Inject(ServiceToken.operationService) private readonly service: IOperationsService) {}

  @Post()
  public async calculate(
    @Body() requestDto: OperationRequestDto,
  ): Promise<OperationResponseDto> {
    return this.service.handle(requestDto);
  }
}
