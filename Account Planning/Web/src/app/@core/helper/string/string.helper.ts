export class StringHelper {

  //#region constructor

  constructor() {
  }

  //#endregion constructor

  //#region public functions

  /**
   * String Format method
   * @param value
   * @param args
   */
  public static format(value: string, ...args: string[]): string {
    if (value) {
      try {
        let val = '';
        let matches = value.match(/{(\d+)}/g);

        if (matches && matches.length > 0) {
          val = value;
          for (let i = 0; i < matches.length; i++) {
            if (args[i] == undefined || args[i] == null) {
              args[i] = '';
            }
            val = val.replace(matches[i], args[i]);
          }
        }
        else {
          return value;
        }
        return val;

      }
      catch (e) {
        return '';
      }
    }
    return '';
  }

  /**
   * concats given args
   * @param args
   */
  public static concat(...args: string[]): string {
    let outValue: string = '';
    if (args && args.length > 0) {
      for (let i = 0; i < args.length; i++) {
        if (args[i]) {
          outValue = `${outValue}${args[i]}`;
        }
      }
    }
    return outValue;
  }

  /**
   * trims the string by handling nulls
   * @param value
   */
  public static toSafeTrim(value: string): string {
    if (value != undefined && value != null) {
      return value.trim();
    }
    return '';
  }

  /**
   * converts all the alphabetic characters in a string to lowercase by handling nulls
   * @param value
   */
  public static toSafeLower(value: string): string {
    if (value != undefined && value != null) {
      return value.toLowerCase();
    }
    return '';
  }

  /**
   * converts all the alphabetic characters in a string to uppercase by handling nulls
   * @param value
   */
  public static toSafeUpper(value: string): string {
    if (value != undefined && value != null) {
      return value.toUpperCase();
    }
    return '';
  }

  //#endregion public functions

}

