export class FileType {
  static dictionary: { [key: string]: number } = {
    'application/pdf': 1,
    'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet': 2,
    'application/vnd.openxmlformats-officedocument.wordprocessingml.document': 3,
    'text/plain': 4,
    'text/csv': 5,
  };

  public static getValue(key: string): number | undefined {
    return this.dictionary[key];
  }
}
