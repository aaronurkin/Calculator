import { Post, Controller } from '@nestjs/common';
import { OperationsService } from './operations.service';

@Controller('operations')
export class OperationsController {
  constructor(private service: OperationsService) {}

  @Post()
  public calculate(requestDto: OperationRequestDto): OperationResponseDto {
    return this.service.handle(requestDto);
  }
}
