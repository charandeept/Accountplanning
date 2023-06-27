import { CoreConstant } from '../../core.constant';


export class ConversionHelper {

   //#region public functions

  //#region int conversions

  /**
   * converts string to number
   * @param value
   */
  public static toNumber(value: string, defaultValue: number = 0): number {
    let convertedVal: number = defaultValue;

    if (value) {
      let number = Number(value);
      if (number) {
        convertedVal = number;
      }
    }

    return convertedVal;
  }

  //#endregion int conversions

  //#region bool conversions

  /**
   * converts string to boolean
   * @param value
   */
  public static toBoolean(value: string, defaultValue: boolean = false): boolean {
    let convertedVal: boolean = defaultValue;
    if (value) {
      if (value.toLowerCase() == CoreConstant.trueVal ||
        value.toLowerCase() == CoreConstant.bitTrueVal ||
        value.toLowerCase() == CoreConstant.yesTrueVal) {
        convertedVal = true;
      }
      else if (value.toLowerCase() == CoreConstant.falseVal ||
        value.toLowerCase() == CoreConstant.bitFalseVal ||
        value.toLowerCase() == CoreConstant.noFalseVal) {
        convertedVal = false;
      }
    }
    return convertedVal;
  }

  //#endregion bool conversions

  //#endregion public functions

}

