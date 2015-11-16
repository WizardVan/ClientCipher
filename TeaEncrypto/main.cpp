#include <iostream>
#include <fstream>
#include <cstring> // for std::strlen
#include <cstddef> // for std::size_t -> is a typedef on an unsinged int

using namespace std;

int main()
{
	ifstream inFile;
	size_t size = 0; // here

	inFile.open("GameCore.dll", ios::in | ios::binary | ios::ate);
	char* oData = 0;

	inFile.seekg(0, ios::end); // set the pointer to the end
	size = inFile.tellg(); // get the length of the file
	cout << "Size of file: " << size;
	inFile.seekg(0, ios::beg); // set the pointer to the beginning

	oData = new char[size + 1]; //  for the '\0'
	inFile.read(oData, size);
	oData[size] = '\0'; // set '\0' 
	cout << " oData size: " << strlen(oData) << "\n";

	//print data
	for (size_t i = 0; i < strlen(oData); i++)
	{
		cout << "oData[" << i << "] " << oData[i];
		cout << "\n";
	}
	inFile.close();
	getchar();
	return 0;
}