import { Post, Controller, Body } from '@nestjs/common';
import { OperationsService } from './operations.service';
import { OperationRequestDto } from '../operations/dto/operation-request.dto';
import { OperationResponseDto } from '../operations/dto/operation-response.dto';

@Controller('operations')
export class OperationsController {
  constructor(private service: OperationsService) {}

  @Post()
  public calculate(
    @Body() requestDto: OperationRequestDto,
  ): OperationResponseDto {
    return this.service.handle(requestDto);
  }
}
